using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneManager : MonoBehaviour
{
    private GameObject _player;
    private Transform _spawnPoint;
    private bool _done;

    void Start()
    {
        _done = false;
        _spawnPoint = gameObject.transform.GetChild(0).gameObject.transform;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D()
    {
        if (_done)
        {
            return;
        }
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");

        _player.GetComponent<Player>().SetspawnPoint(_spawnPoint);
        foreach (GameObject floor in floors)
        {
            if (floor)
                floor.GetComponent<RespawnPlayer>().SetspawnPoint(_spawnPoint);
        }
        _done = true;
    }
}