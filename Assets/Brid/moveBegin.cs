using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBegin : MonoBehaviour
{
    public float target;
    public Animator fade;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < target)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * 100, transform.position.y);
        }
        if(transform.position.x >= 0)
        {
            Time.timeScale = 1;
            transform.position = new Vector3(0, transform.position.y);
            Destroy(GetComponent<moveBegin>());
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            fade.SetTrigger("FadeIn");
        }
    }
}
