using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColoredObject : MonoBehaviour
{

    static List<ColoredObject> coloredObjects = new List<ColoredObject>();

    // Possible colors
    public enum Colors { RED, GREEN, BLUE, YELLOW, PINK }

    // Value of the colors
	Color red = new Color(1, 0, 0, 1);
	Color green = new Color(0, 1, 0, 1);
	Color blue = new Color(0, 0.3f, 1, 1);
	Color yellow = new Color(1, 1, 0, 1);
	Color pink = new Color(1, 0.2f, 0.8f, 1);

    private Colors currentColor;

    private SpriteRenderer sprite;

    // Return the value of the color
    public Color getColor(Colors c)
    {
        switch (c)
        {
            case Colors.RED:
                return red;
            case Colors.GREEN:
                return green;
            case Colors.BLUE:
                return blue;
            case Colors.YELLOW:
                return yellow;
            case Colors.PINK:
                return pink;
            default:
                return red;
        }
    }

    protected Colors getCurrentColor()
    {
        return currentColor;
    }

    public void setCurrentColor(Colors c)
    {
        currentColor = c;
        applyColor(c);
    }

    protected void init()
    {
        ColorManager.addColoredObject(this);
        sprite = GetComponent<SpriteRenderer>();
    }

    // Method called when the color is updated by the time
    public abstract void changeColor();

    protected void applyColor(Colors c)
    {
        sprite.color = getColor(c);
    }

    public bool IsSameColor(GameObject obj)
    {
        ColoredObject colobj = obj.GetComponent<ColoredObject>();
        if(colobj!=null)
        {
            return colobj.getCurrentColor() == this.getCurrentColor();
        }
        SpriteRenderer objsprite = obj.GetComponent<SpriteRenderer>();
        if (objsprite != null)
        {
            return objsprite.color == getColor(this.getCurrentColor());
        }
        return false;
    }

    public bool IsSameColor(ColoredObject obj)
    {
        return this.getCurrentColor() == obj.getCurrentColor();
    }
    public bool IsSameColors(Color obj)
    {
        return getColor(this.getCurrentColor()) == obj;
    }
}
