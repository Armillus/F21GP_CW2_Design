using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColour : MonoBehaviour
{
    public GameObject player;

    //The heart will delete itself and add an available colour to the player
    void OnTriggerEnter2D()
    {
        this.gameObject.SetActive(false);
        player.GetComponent<ColoredPlayer>().AddAvailableColor();
    }
}
