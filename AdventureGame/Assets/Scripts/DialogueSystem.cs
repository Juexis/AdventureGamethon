using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.Analytics;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public Interactable InteractScript;
    public PlayerMovement Pmove;
    string dialogue;
    string objectName;
    [SerializeField] private Health playerHealth;


    private void Start()
    {
        //InteractScript = gameObject.GetComponent<Interactable>();
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
            case "Bed":
                Pmove.InDialogue();
                dialogue = "You are not tired...";
                UpdateText(dialogue);
                break;
        }
    }



}
