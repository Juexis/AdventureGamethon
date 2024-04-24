using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    bool attacking = false;
    public BoxCollider2D attackBox;
    float pushRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        attackBox = GameObject.Find("Attack Range").GetComponent<BoxCollider2D>();
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
    [SerializeField] private float dmgValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().deleteHealth(dmgValue);
            DoPush();

        }
    }

    void DoPush()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pushRadius);

        foreach (Collider2D pushedObject in colliders)
        {
            if (pushedObject.CompareTag("Enemy"))
            {
                Rigidbody2D pushedBody = pushedObject.GetComponent<Rigidbody2D>();

                // Get direction from your postion toward the object you wish to push
                var direction = pushedBody.transform.position - transform.position;

                // Normalization is important, to have constant unit!
                pushedBody.AddForce(direction.normalized * 50, ForceMode2D.Force);

            }
        }
    }
}
