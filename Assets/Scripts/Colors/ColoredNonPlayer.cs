using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredNonPlayer : ColoredObject
{
    [Tooltip("Set to true if the object doesn't change color")]
    public bool fixedColor = false;

    public Colors[] colorList = { Colors.RED, Colors.BLUE, Colors.GREEN, Colors.YELLOW };

    public bool isRandom = false;

    private void Start()
    {
        if (colorList.Length == 0)
        { 
            colorList = new Colors[]{ Colors.PINK};
            Debug.Log(this.name + " has no color specified"); 
        }

        init();
        setCurrentColor(colorList[0]);
        applyColor(getCurrentColor());
    }


    public override void changeColor()
    {
        if (!fixedColor)
        {
            Colors col = isRandom ? getRandomColor() : getNextColor();
            applyColor(col);
            setCurrentColor(col);
        }
    }

    private Colors getRandomColor()
    {
        List<Colors> availableColors = new List<Colors>();
        foreach(Colors col in colorList)
        {
            if (col != getCurrentColor())
            {
                availableColors.Add(col);
            }
        }
        int ind = (int)Random.Range(0, availableColors.Count);
        return availableColors[ind];
    }

    private Colors getNextColor()
    {
        int ind = indexCurrentColor();
        return colorList[(ind + 1) % colorList.Length];
    }

    private int indexCurrentColor()
    {
        for(int i = 0; i < colorList.Length; i++)
        {
            if (colorList[i] == getCurrentColor())
            {
                return i;
            }
        }
        return 0;
    }

}
