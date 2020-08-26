using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public spawnItem[] items;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Bird>().gameObject;
        foreach(spawnItem i in items)
        {
            i.spawn = player.transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (spawnItem i in items)
        {
            if (Mathf.Abs(player.transform.position.x - i.spawn) > i.freq)
            {
                Instantiate(i.m_gameObject, i.offset + new Vector3(player.transform.position.x, Random.Range(i.spawnRange.x, i.spawnRange.y)), Quaternion.identity);
                i.spawn = player.transform.position.x;
            }
            
        }
    }
}
