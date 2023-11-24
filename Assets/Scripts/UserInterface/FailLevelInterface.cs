using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailLevelInterface : MonoBehaviour
{
    void Start()
    {

    }

    Vector2 GetScreenSize()
    {
        return new Vector2(Screen.width, Screen.height);
    }

    bool RenderButton(string szLabel, Vector2 vecPosition, Vector2 vecSize)
    {
        return GUI.Button(new Rect(vecPosition.x - (vecSize.x / 2f), vecPosition.y - (vecSize.y / 2f), vecSize.x, vecSize.y), szLabel);
    }
    void FixedUpdate()
    {

    }
    void OnGUI()
    {
        Vector2 vecScreenSize = GetScreenSize();

        GUI.Label(new Rect(10, 10, 90, 30), "build v1.4");

        GUI.Label(new Rect(vecScreenSize.x / 2f - 70, vecScreenSize.y / 2f - 60, 200, 30), "You couldnt pass the level");

        if (RenderButton("Try again", new Vector2(vecScreenSize.x / 2f, vecScreenSize.y / 2f), new Vector2(90, 30)))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene != null)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (RenderButton("Exit", new Vector2(vecScreenSize.x / 2f, (vecScreenSize.y / 2f + 50)), new Vector2(50, 30)))
        {
            Application.Quit();
        }


    }
    void Update()
    {

    }
}
