using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;

public class ObjetiveController : MonoBehaviour
{
    // Start is called before the first frame update

    public int iObjective = 0;
    void OnGUI()
    {
        if (iObjective == 0)
        GUI.Label(new Rect(10, 300, 280, 30), "Collect cubes to reach objective location");

    }
}
