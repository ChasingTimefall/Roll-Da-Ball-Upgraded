using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GUI.Label(new Rect(10, 10, 280, 30), "Press escape to return to main menu");

        if (TextStyle == null)
        {
            TextStyle = new GUIStyle(GUI.skin.label);
            TextStyle.fontSize = 30;
            TextFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
            TextStyle.font = TextFont;
            TextStyle.normal.textColor = Color.red;
            TextStyle.hover.textColor = Color.red;
        }

        GUI.Label(new Rect(10, 90, 130, 130), "Score : " + iScore, TextStyle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene != null)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        
    }
}
