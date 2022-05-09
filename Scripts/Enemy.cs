using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 movement;
    public float moveSpeed;
    public float copySpeed;
    public Transform player;
    NavMeshAgent Agent;
    public float distance;
    public Animator anim;
    bool isDead;

    int damage;

    public Transform attackPoint;
    // Range of our attacks
    public float attackRange;
    // who to collide with
    public LayerMask enemyLayers;
    // damage variable 

    [SerializeField] private int maxHealth;
    private int currentHealth;
    void Start()
    {

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        distance = Vector3.Distance(transform.position, player.position);
        if (!isDead)
            if (distance > 1f)
            {
                moveSpeed = copySpeed;
                anim.SetFloat("speed", moveSpeed);
                Movement(movement);
                transform.LookAt(player);
            }
            else
            {
                anim.SetFloat("speed", 0);
                moveSpeed = 0;
            }
    }
    void Movement(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * moveSpeed / 10 * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // play hurt animation
        anim.SetTrigger("hurt");
        if (currentHealth <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died");
        // die animation
        anim.SetBool("isDead", true);
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
    public void Attack()
    {

    }

    public IEnumerator Damage()
    {
        // Creates enemy colliders if we hit them we can damage them
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            yield return new WaitForSeconds(0.5f);
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
