using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public int iScore = 0;
    GUIStyle TextStyle;
    Font TextFont;
    void Start()
    {
       
    }

    void OnGUI()
    {
        if (TextStyle == null)
        {
            TextStyle = new GUIStyle(GUI.skin.label);
            TextStyle.fontSize = 30;
            TextFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
            TextStyle.font = TextFont;
            TextStyle.normal.textColor = Color.red;
            TextStyle.hover.textColor = Color.red;
        }
        // Load and set Font


        // Set color for selected and unselected buttons



        GUI.Label(new Rect(10, 90, 130, 130), "Score : " + iScore, TextStyle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
