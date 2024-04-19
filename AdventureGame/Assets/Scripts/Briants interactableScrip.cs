using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BInteractable : MonoBehaviour
{
    public bool canInteract;
    public KeyCode keyCode = KeyCode.E;
    public string objectName;
    public string inRange;
    public DialogueSystem dialogueSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log("play dialog");
                dialogueSystem.GenerateDialogue(objectName);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectName = transform.parent.name;
            inRange = gameObject.name;
            Debug.Log(objectName);
            Debug.Log("can interact");
            dialogueSystem.Inrangenow(inRange);  
            canInteract = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("can't interact");
            inRange = null;
            dialogueSystem.Inrangenow(inRange);
            canInteract = false;
        }
    }
}
