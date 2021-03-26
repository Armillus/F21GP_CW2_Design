using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;

    public void SetspawnPoint(Transform newspawnPoint)
    {
        spawnPoint = newspawnPoint;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            //enlever 5%
            //assigner la couleur
            //Wheel.SynchroniseToPlayer()
            //hunger bar à 50
            collider.transform.position = spawnPoint.position;
        }
    }

}
