using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    public Timer timer;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(timer.GameOver());
    }
}
