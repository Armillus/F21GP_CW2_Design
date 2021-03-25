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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = spawnPoint.position;
        }
    }
}
