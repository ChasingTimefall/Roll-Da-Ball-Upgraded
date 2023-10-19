using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InLevelInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector2 GetScreenSize()
    {
        return new Vector2(Screen.width, Screen.height);
    }

    void OnGUI()
    {
        Vector2 vecScreenSize = GetScreenSize();

        GUI.Label(new Rect(10, 10, 90, 30), "build v1.2");

    }
    void Update()
    {
        
    }
}
