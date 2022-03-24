using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        if(currentHealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("Enemy died");
        
        // die animation

        // disable enemy
    }
    
}
