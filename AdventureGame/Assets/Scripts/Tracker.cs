using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tracker
{
    public GameObject source;
    private GameObject target;
    // Start is called before the first frame updat
    public Tracker(GameObject sourceObject, string targetName)
    {
        source = sourceObject;
        target = GameObject.Find(targetName);
    }

    public Vector2 GetDirection()
    {

        Vector2 targetPos = target.transform.position;

        Vector2 sourcePos = source.transform.position;

        Vector2 direction = targetPos - sourcePos;
        direction.Normalize();

        return direction;
    }
}
