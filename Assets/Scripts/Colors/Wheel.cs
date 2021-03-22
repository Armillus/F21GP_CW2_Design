using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    private Image img;
    public Sprite wheel1;
    public Sprite wheel2;
    public Sprite wheel3;
    public Sprite wheel4;
    public Sprite wheel5;
    public ColoredPlayer player;

    private int status;

    int rotationDegree;

    void Start()
    {
        img = this.GetComponent<Image>();
        status = 1;
    }

    void Update()
    {
        ClickCheck();
        if (status != player.GetNumAvailableColors())
        {
            transform.rotation = Quaternion.identity;
            status = player.GetNumAvailableColors();
            switch (status)
            {
                case 1:
                    img.sprite = wheel1;
                    rotationDegree = 0;
                    break;
                case 2:
                    img.sprite = wheel2;
                    rotationDegree = 90;                  
                    break;
                case 3:
                    img.sprite = wheel3;
                    rotationDegree = 120;
                    break;
                case 4:
                    img.sprite = wheel4;
                    rotationDegree = 90;
                    break;
                case 5:
                    img.sprite = wheel5;
                    rotationDegree = 72;
                    break;
                default:
                    break;
            }
            transform.Rotate(Vector3.forward * rotationDegree / 2);
            transform.Rotate(Vector3.forward * rotationDegree * (int)player.GetColor()); 
        }
    }

    public void ColorRight()
    {
        transform.Rotate(Vector3.forward * rotationDegree);
    }

    public void ColorLeft()
    {
        transform.Rotate(Vector3.back * rotationDegree);
    }

    private void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ColorLeft();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ColorRight();
        }
    }
}
