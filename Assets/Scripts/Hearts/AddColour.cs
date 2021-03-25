using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColour : MonoBehaviour
{
    public GameObject player;
    private bool _done;

    void Start()
    {
        _done = false;
    }
    //The heart will delete itself and add an available colour to the player
    void OnTriggerEnter2D()
    {
        if (_done)
        {
            return;
        }
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");

        this.gameObject.SetActive(false);
        player.GetComponent<ColoredPlayer>().AddAvailableColor();
        player.GetComponent<Player>().SetspawnPoint(transform);
        foreach (GameObject floor in floors)
        {
            if (floor)
                floor.GetComponent<RespawnPlayer>().SetspawnPoint(transform);
        }
        _done = true;
    }
}
