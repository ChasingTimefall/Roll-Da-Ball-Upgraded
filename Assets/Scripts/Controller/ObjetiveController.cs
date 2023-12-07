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
         GUI.Label(new Rect(10, 300, 380, 30), "Objective : Collect cubes to reach objective location");
        else if (iObjective == 1)
         GUI.Label(new Rect(10, 300, 380, 30), "Objective : Collect hidden cubes in the area");

    }
}
