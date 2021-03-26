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
            collider.transform.position = spawnPoint.position;
        }
    }

}
