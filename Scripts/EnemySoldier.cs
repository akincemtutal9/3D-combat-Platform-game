using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldier : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePoint;
   
    public void Shoot()
    {
      Rigidbody rb = Instantiate(projectile, projectilePoint.position , Quaternion.identity).GetComponent<Rigidbody>();
      rb.AddForce(transform.forward * 28f, ForceMode.Impulse);
      rb.AddForce(transform.up * 6f, ForceMode.Impulse);  
    }
}
