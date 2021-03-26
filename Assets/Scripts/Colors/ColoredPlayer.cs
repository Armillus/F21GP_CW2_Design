using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredPlayer : ColoredObject
{
    public int availableColors;

    // meant to be empty because the color of the player doesn't change on the rythm
    public override void changeColor(){}

    private void Start()
    {
        init();
        this.setCurrentColor(Colors.RED);
        applyColor(getCurrentColor());
        //availableColors = 1;
    }

    public void ApplyNextColor()
    {
        setCurrentColor((Colors)(((int)getCurrentColor() + 1) % availableColors));
        applyColor(getCurrentColor());
    }

    public void ApplyPreviousColor()
    {
        setCurrentColor((Colors)(((int)getCurrentColor() - 1 + availableColors) % availableColors));
        applyColor(getCurrentColor());
    }

    public Colors GetColor()
    {
        return getCurrentColor();
    }

    public void AddAvailableColor()
    {
        if (availableColors < 5) availableColors++;
    }

    public void RemoveAvailableColor()
    {
        if (availableColors > 1) availableColors--;
    }

    public bool IsAvailable(Colors c)
    {
        switch (c)
        {
            case Colors.RED:
                return true;
            case Colors.GREEN:
                return availableColors > 1;
            case Colors.BLUE:
                return availableColors > 2;
            case Colors.YELLOW:
                return availableColors > 3;
            case Colors.PINK:
                return availableColors > 4;
            default:
                return false;
        }
    }

    public int GetNumAvailableColors()
    {
        return availableColors;
    }
}
