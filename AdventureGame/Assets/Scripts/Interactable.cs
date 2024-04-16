using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    string objectName;
    public GameObject Player;
    public DialogueSystem Ds;
    private void Start()
    {
        objectName = gameObject.name;
    }

    private void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && (Input.GetButton("Fire1")))
        {
            Ds.GenerateDialogue(objectName);
        }
    }
}

