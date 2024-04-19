using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1.04F;

    Tracker myTracker;

    // Use this for initialization
    void Start()
    {
        myTracker = new Tracker(gameObject, "Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = myTracker.GetDirection();

        transform.Translate(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);
    }

    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().deleteHealth(healthValue);


        }
    }



}
