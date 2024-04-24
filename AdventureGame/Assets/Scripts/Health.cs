using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    //Iframes
    [SerializeField] private float invulnerabilityTime;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;

        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage (float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(iframes());
        }
    }
    private void Update()
    {

    }

    public void addHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void deleteHealth( float _value)
    {
        TakeDamage(1);
    }

    private IEnumerator iframes()
    {
        Physics2D.IgnoreLayerCollision(6, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(0.6603f, 0.6603f, 0.6603f, 0.5f);
            yield return new WaitForSeconds(invulnerabilityTime / (numberOfFlashes *2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerabilityTime / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 10, false);
    }
}

