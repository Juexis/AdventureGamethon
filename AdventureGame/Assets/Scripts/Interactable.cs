using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    string objectName;
    public GameObject Player;
    private void Start()
    {
        objectName = gameObject.name;
    }

    private void Update()
    {


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetButton("Fire1"))
        {
            GetName();
        }
    }
    public string GetName()
    {
        return objectName;
    }
}

