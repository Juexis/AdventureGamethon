using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public Interactable InteractScript;
    public PlayerMovement PlayerMovement;
    string dialogue;
    string objectName;
    bool inDialogue = false;

    private void Start()
    {
        //InteractScript = gameObject.GetComponent<Interactable>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            objectName = InteractScript.GetName();
            Debug.Log("2");

            switch (objectName)
            {
                case "Bed":
                    dialogue = "You are not tired...";
                    Debug.Log("3");
                    UpdateText(dialogue);
                    inDialogue = true;
                    pause();
                    if (Input.GetButtonDown("Fire1"))
                    {

                        inDialogue = false;
                        pause();
                    }
                    
                    break;
            }
        }
    }


    public void UpdateText(string dialogue)
    {
        textbox.text = dialogue;
    } 

    public bool pause()
    {
        if (inDialogue)
        {
            Debug.Log("4");
        }
        return inDialogue;

    }
}
