using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 4;
    float horizontalInput;
    float verticalInput;
    public Animator playerAnim;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;

        Debug.Log(horizontalInput + " " + verticalInput);

        //set player animations
        playerAnim.SetFloat("Horizontal", rb.velocity.x);
        playerAnim.SetFloat("Vertical", rb .velocity.y);

        //checks if last input given and sets it to the lastmove variables
        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
        {
            playerAnim.SetFloat("lastmoveX", Input.GetAxis("Horizontal"));
            playerAnim.SetFloat("lastmoveY", Input.GetAxis("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
    }

}
