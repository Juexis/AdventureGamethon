using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SlimeMove : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1.04F;
    private PlayerMovement player;
    Tracker myTracker;
    float pushRadius = 15f;
    public bool isKilled;
    [SerializeField] private Health slimeHealth;

    void Start()
    {
        myTracker = new Tracker(gameObject, "Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = myTracker.GetDirection();
        transform.Translate(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);

        //slime death
        if (this.slimeHealth.currentHealth <= 0)
        {
            isKilled = true;
            Debug.Log(isKilled +"iskiulled");
            Destroy(gameObject);
        }
    }

    [SerializeField] private float dmgValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
            if (pushedObject.CompareTag("Player"))
            {
                Rigidbody2D pushedBody = pushedObject.GetComponent<Rigidbody2D>();

                // Get direction from your postion toward the object you wish to push
                var direction = pushedBody.transform.position - transform.position;

                // Normalization is important, to have constant unit!
                pushedBody.AddForce(direction.normalized * 2500, ForceMode2D.Force);

            }
        }

    }
 }
