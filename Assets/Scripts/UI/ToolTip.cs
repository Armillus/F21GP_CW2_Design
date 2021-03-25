using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    [TextArea(3,10)]
    public string insight;

    public float width = 300f;
    public float height = 80f;
    public int fontSize = 20;
    public int horizontalOffset = -150;
    public int verticalOffset = 20;

    private bool _enabled = false;

    private void OnMouseOver()
    {   
        _enabled = true;
    }

    private void OnMouseExit()
    {
        _enabled = false;    
    }

    private void OnGUI()
    {
        if (_enabled)
        {
            float x = Event.current.mousePosition.x;
            float y = Event.current.mousePosition.y;

            GUIStyle style = new GUIStyle(GUI.skin.textArea);
            style.fontSize = fontSize;

            GUI.TextArea(new Rect (x + horizontalOffset, y + verticalOffset, width, height), insight, style);
        }
    }
}
