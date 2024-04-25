using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 4;
    float horizontalInput;
    float verticalInput;
    public bool inDialogue;
    public Animator playerAnim;
    public Animator attackAnim;
    public Rigidbody2D rb;
    bool gameOver;
    [SerializeField] private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //INPUTS
        //movement
        if (!inDialogue && !gameOver)
        {
           horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime;
           verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;

            //handle animations
            PlayerAnimations();
        }

        if (playerHealth.currentHealth <= 0)
        {
            gameOver = true;
            horizontalInput = 0;
            verticalInput = 0;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
    }

    public void InDialogue()
    {
        inDialogue = true;
    }

    public void PlayerAnimations()
    {
        //set player animations
        playerAnim.SetFloat("Horizontal", rb.velocity.x);
        playerAnim.SetFloat("Vertical", rb.velocity.y);

        //checks if last input given and sets it to the lastmove variables
        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            playerAnim.SetFloat("lastmoveX", Input.GetAxis("Horizontal"));
            playerAnim.SetFloat("lastmoveY", Input.GetAxis("Vertical"));
            attackAnim.SetFloat("lastmoveX", Input.GetAxis("Horizontal"));
            attackAnim.SetFloat("lastmoveY", Input.GetAxis("Vertical"));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            playerAnim.SetTrigger("Attacking");
            attackAnim.SetTrigger("Attacking");
        }
    }

}
