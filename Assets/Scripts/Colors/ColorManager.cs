using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorManager : ScriptableObject
{
    private static List<ColoredObject> coloredObjects = new List<ColoredObject>();

    public static void addColoredObject(ColoredObject obj)
    {
        if (!coloredObjects.Contains(obj))
        {
            coloredObjects.Add(obj);
        }
    }

    public static void updateColors()
    {
        foreach(ColoredObject obj in coloredObjects)
        {
            if (obj != null) { obj.changeColor(); } // null if destroyed
        }
    }

    public static int size()
    {
        return coloredObjects.Count;
    }
}
