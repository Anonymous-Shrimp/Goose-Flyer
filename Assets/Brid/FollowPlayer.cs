using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    public bool followY = false;
    private Vector3 orginal;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Bird>().transform;
        orginal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        if (!followY)
        {
            transform.position = new Vector3(transform.position.x, orginal.y);
        }
    }
}
