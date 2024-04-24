using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    bool attacking = false;
    public BoxCollider2D attackBox;
    // Start is called before the first frame update
    void Start()
    {
        attackBox= GameObject.Find("Attack Range").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            attacking = true;
            attackBox.enabled = true;
        }
        else
        {
            attackBox.enabled = false;
        }
    }
}
