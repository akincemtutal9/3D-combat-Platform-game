using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    public float radius = 3;
    public int damageAmount = 50;
   
    private void Start()
    {

    }
    private void Update()
    {
        StartCoroutine(DestroySphereBullet());
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 1);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            if(nearbyObject.tag == "Player")
            {
                StartCoroutine(FindObjectOfType<PlayerManager>().TakeDamage(damageAmount));
                //FindObjectOfType<PlayerManager>()
            }
        }
        GetComponent<SphereCollider>().enabled = false;
        this.enabled = false;
    }
    private IEnumerator DestroySphereBullet()
    {   
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
