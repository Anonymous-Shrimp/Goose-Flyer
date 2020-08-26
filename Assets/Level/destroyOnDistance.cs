using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnDistance : MonoBehaviour
{
    Transform player;
    public float destroyDistance = 1000;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Bird>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(player.transform.position.x - transform.position.x > destroyDistance)
            {
                Destroy(gameObject);
            }
            if(transform.position.x - player.position.x > destroyDistance + 100)
            {
                Destroy(gameObject);
            }
        }
    }
}
