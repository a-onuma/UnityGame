using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    public Vector3 find(string name)
    {
        return GameObject.Find(name).transform.position;
    }
}
