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

        if (verticalInput < 0)
        {
            playerAnim.SetFloat("Vertical", -1);
        }
        else if (verticalInput > 0)
        {
            playerAnim.SetFloat("Vertical", 1);
        }
        else
        {
            playerAnim.SetFloat("Vertical", 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
    }

}
