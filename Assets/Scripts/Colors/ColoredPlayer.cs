using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredPlayer : ColoredObject
{
    // meant to be empty because the color of the player doesn't change on the rythm
    public override void changeColor(){}

    public void rightClickColor()
    {
        int available = getNumAvailableColors();
        setCurrentColor((Colors)(((int)getCurrentColor() + 1) % available));
        applyColor(getCurrentColor());
    }

    public void leftClickColor()
    {
        int available = getNumAvailableColors();
        setCurrentColor((Colors)(((int)getCurrentColor() - 1 + available) % available));
        applyColor(getCurrentColor());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
