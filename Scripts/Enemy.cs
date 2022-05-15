using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isDead;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died");
        //disable enemy
        isDead = true;
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}
