using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public Interactable InteractScript;
    public PlayerMovement Pmove;
    string dialogue;
    string objectName;

    private void Start()
    {
        //InteractScript = gameObject.GetComponent<Interactable>();
    }
    private void Update()
    {

    }

    public void UpdateText(string dialogue)
    {
        textbox.text = dialogue;
    } 

    public void GenerateDialogue(string name)
    {
        objectName = name;

        switch (objectName)
        {
            case "Bed":
                Pmove.InDialogue();
                dialogue = "You are not tired...";
                UpdateText(dialogue);
                break;
        }
    }
}
