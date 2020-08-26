using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Rewind
{
    public Vector3 pos;
    public Vector3 vel;
    public Quaternion rot;
    
    public Rewind (Vector3 _pos, Vector3 _vel, Quaternion _rot)
    {
        pos = _pos;
        vel = _vel;
        rot = _rot;
    }
}
