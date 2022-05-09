using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Animator anim;
    bool isDead;
    int maxHealth;
    public int currentHealth;

    public Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        anim.GetComponent<Animator>();
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
        if (currentHealth <= 0)
        {
            Invoke(nameof(DestroyPlayer), 0.5f);
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Player died");
        // die animation
        anim.SetBool("isDead", true);
        //disable enemy
        StartCoroutine(DestroyCollider());
        this.enabled = false;
        isDead = true;
    }
    public IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
    public IEnumerator DestroyCollider()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<CapsuleCollider>().enabled = false;
        
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Additive);
    }

}
