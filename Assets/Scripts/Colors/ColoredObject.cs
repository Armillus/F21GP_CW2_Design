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
	Color blue = new Color(0.3f, 0.3f, 1, 1);
	Color yellow = new Color(1, 1, 0, 1);
	Color pink = new Color(1, 0.2f, 0.8f, 1);

    [Tooltip("The initial color and the colors before will also be available")]
    public Colors initialColor = Colors.RED;
    private Colors currentColor;

    private SpriteRenderer sprite;

    [Tooltip("If the initial color is not the last available color, please define how much colors are available")]
    [Range(2,5)]
    public int nbColorsAvailable = 2;
    private int availableColors;

    // Return the value of the color
    private Color getColor(Colors c)
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

    protected void setCurrentColor(Colors c)
    {
        currentColor = c;
    }

    void Start()
    {
        ColorManager.addColoredObject(this);
        sprite = GetComponent<SpriteRenderer>();
        availableColors = nbColorsAvailable;
        this.applyColor(initialColor);
        currentColor = initialColor;
        while (!isAvailable(initialColor))
        {
            addAvailableColor();
        }
    }

    public void addAvailableColor()
    {
        if (availableColors < 5) availableColors++;
    }

    public void removeAvailableColor()
    {
        if (availableColors > 2) availableColors--;
    }

    protected bool isAvailable(Colors c)
    {
        switch (c)
        {
            case Colors.RED:
                return true;
            case Colors.GREEN:
                return true;
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

    protected int getNumAvailableColors()
    {
        return availableColors;
    }

    // Method called when the color is updated by the time
    public abstract void changeColor();

    protected void applyColor(Colors c)
    {
        sprite.color = getColor(c);
    }

    public bool isSameColor(GameObject obj)
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
}
