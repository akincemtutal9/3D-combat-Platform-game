using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerChild : MonoBehaviour
{
    public bool isOnMovingPlatform = false;
    public GameObject player;
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnMovingPlatform)
        {
            player.transform.SetParent(this.transform);
        }
        else
        {
            player.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isOnMovingPlatform = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnMovingPlatform = false;
        }   
    }
}
