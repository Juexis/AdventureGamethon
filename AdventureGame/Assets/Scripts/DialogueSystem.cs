using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public Interactable InteractScript;
    string dialogue;
    string objectName;

    private void Start()
    {
        //InteractScript = gameObject.GetComponent<Interactable>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            InteractScript.GetName();

            switch (objectName)
            {
                case "Bed":
                    dialogue = "You are not tired...";
                    UpdateText(dialogue);
                    break;
            }
        }
    }

    public void UpdateText(string dialogue)
    {
        textbox.text = dialogue;
    } 
}
