using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;

    public float currentHealth;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 80;
    }

    public void TakeDamge(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
