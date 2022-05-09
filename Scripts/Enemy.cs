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
    private void Update()
    {
        Die();

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        if (currentHealth <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died");
        //disable enemy
        StartCoroutine(DestroyCollider());
        this.enabled = false;
        isDead = true;
    }
    public IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public IEnumerator DestroyCollider()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
