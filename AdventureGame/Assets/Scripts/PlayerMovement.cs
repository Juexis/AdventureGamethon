using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 4;
    float horizontalInput;
    float verticalInput;
    public Animator playerAnim;
    public Rigidbody2D rb;
    public Interactable InteractScript;
    public DialogueSystem DialougeSystem;
    private string objectName2;
    bool stopmovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //INPUTS
        //movement
        stopmovement = DialougeSystem.pause();
        if (stopmovement)
        {
            Debug.Log("5");
        }
        if (!stopmovement)
        {
            horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime;
            verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;

            //interact

            //set player animations
            playerAnim.SetFloat("Horizontal", rb.velocity.x);
            playerAnim.SetFloat("Vertical", rb.velocity.y);

            //checks if last input given and sets it to the lastmove variables
            if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
            {
                playerAnim.SetFloat("lastmoveX", Input.GetAxis("Horizontal"));
                playerAnim.SetFloat("lastmoveY", Input.GetAxis("Vertical"));
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log(collision.gameObject.name);
        }
        
    }


    public string GetName2()
    {
        return objectName2;
    }

    private void FixedUpdate()
    {
        if (!stopmovement)
        {
            rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        }

    }

}
