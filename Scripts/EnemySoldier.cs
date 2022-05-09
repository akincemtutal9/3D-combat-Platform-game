using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Shoot()
    {
      Rigidbody rb = Instantiate(projectile, projectilePoint.position , Quaternion.identity).GetComponent<Rigidbody>();
      rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
      rb.AddForce(transform.up * 7f, ForceMode.Impulse);  
    }
}
