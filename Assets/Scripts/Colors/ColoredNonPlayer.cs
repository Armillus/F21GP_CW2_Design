using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredNonPlayer : ColoredObject
{
    [Tooltip("Set to true if the object doesn't change color")]
    public bool fixedColor = false;

    public override void changeColor()
    {
        if (!fixedColor)
        {
            Colors rand = getRandomColor();
            applyColor(rand);
            setCurrentColor(rand);
        }
    }

    private Colors getRandomColor()
    {
        List<Colors> availableColors = new List<Colors>();
        for(int i = 0; i < 5; i++)
        {
            Colors col = (Colors)i;
            if (isAvailable(col) && col!=getCurrentColor())
            {
                availableColors.Add(col);
            }
        }
        int ind = (int)Random.Range(0, availableColors.Count);
        return availableColors[ind];
    }
}
