using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bedtext : MonoBehaviour
{
    public TextMeshProUGUI bedText;
    bool text1 = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bedText.text = "This is a bed";
            text1 = true;
            while (text1 == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bedText.text = "You are not sleepy";
                }
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        bedText.text = "";
    }
}
