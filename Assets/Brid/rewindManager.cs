using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class rewindManager : MonoBehaviour
{
    public Slider slider;
    public PostProcessVolume FX;
    public float FXWeight;
    public Bird bird;
    public float juiceDecrease;

    public Animator blackPanel;
    public bool rewindPress = false;
    public bool rewind = false;

    [HideInInspector]
    public float juice = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>();
        FX.weight = FXWeight;
        bird = FindObjectOfType<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        rewindPress = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        
        if(FX.weight > FXWeight)
        {
            FX.weight -= Time.deltaTime;
        }
        else if (FX.weight < FXWeight)
        {
            FX.weight += Time.deltaTime;
        }
        if(rewindPress && juice > 0)
        {
            bird.gameObject.SetActive(true);
            bird.isDead = false;
            juice -= Time.deltaTime / juiceDecrease;
            rewind = true;
            FXWeight = 1;
        }
        else
        {
            rewind = false;
            FXWeight = 0;
        }
        if(juice > 1)
        {
            juice = 1;
        }
        slider.value = juice;
        if(bird.isDead && juice <= 0)
        {
            //You ded for good
            blackPanel.SetTrigger("FadeOut");
            StartCoroutine(wait(1));
        }
        IEnumerator wait(float sec)
        {
            yield return new WaitForSeconds(sec);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
