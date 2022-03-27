using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    public Animator anim;


    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        anim.SetTrigger("hurt");    
        if(currentHealth <= 0)
        {           
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died");

        // die animation
        anim.SetBool("isDead", true);
        // disable enemy
        //GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<CapsuleCollider>().transform.Rotate(new Vector3(0, 90, 0));
        this.enabled = false;
    }
    
}
