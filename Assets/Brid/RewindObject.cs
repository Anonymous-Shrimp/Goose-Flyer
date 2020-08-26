using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindObject : MonoBehaviour
{
    public bool isRewinding = false;
    public float recordTime = 10f;
    public List<Rewind> pointInTime;
    Rigidbody2D rb;
    public rewindManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pointInTime = new List<Rewind>();
        manager = FindObjectOfType<rewindManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.rewind)
        {
            StartRewind();
        }
        else
        {
            StopRewind();
        }
    }
    public void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    void Rewind()
    {
        {
            if(pointInTime.Count > 0)
            {
                Rewind point = pointInTime[0];
                transform.position = point.pos;
                transform.rotation = point.rot;
                rb.velocity = point.vel;

                pointInTime.RemoveAt(0);
            }
            else
            {
                StopRewind();
            }
        }
    }
    void Record()
    {
        if (pointInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointInTime.RemoveAt(pointInTime.Count - 1);
        }
        pointInTime.Insert(0, new Rewind(transform.position, rb.velocity, transform.rotation));
    }
    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }
    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
