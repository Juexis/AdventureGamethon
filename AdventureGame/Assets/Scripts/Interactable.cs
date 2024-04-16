using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private string objectName;
    public GameObject Player;
    private void Start()
    {
        
    }

    private void Update()
    {
        objectName = "";
        GetName();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetButtonDown("Fire1"))
        {
            objectName = gameObject.name;
            GetName();
            Debug.Log("1");

        }
    }





    public string GetName()
    {
        return objectName;
    }
}

