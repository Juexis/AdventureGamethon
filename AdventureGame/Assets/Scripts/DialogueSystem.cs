using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.Analytics;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public BInteractable InteractScript;
    public PlayerMovement Pmove;
    string dialogue;
    string objectName;
    [SerializeField] private Health playerHealth;
    string status;

    private void Start()
    {
        //InteractScript = gameObject.GetComponent<Interactable>();
        textbox.text = string.Empty;
    }
    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            textbox.text = "Game Over.";
        }
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
            case "InteractableRange":
                dialogue = "Press E to interact";
                Debug.Log("Interactable");
                UpdateText(dialogue);
                break;
            case "Bed":
                Pmove.InDialogue();
                dialogue = "You are not tired...";
                Debug.Log("you are not tired");
                UpdateText(dialogue);
                break;
            case "Door":
                Pmove.InDialogue();
                dialogue = "You don't feel like leaving yet.";
                Debug.Log("door");
                UpdateText(dialogue);
                break;
        }
    }

    public void Inrangenow(string dialogHitbox)
    {
        status = dialogHitbox;
        switch (status)
        {
            case "InteractableRange":
                dialogue = "Press E to interact";
                Debug.Log("interactable");
                UpdateText(dialogue);
                break;
            default:
                dialogue = string.Empty;
                UpdateText(dialogue);
                break;

        }


    }



    }
