using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameObject LevelInf;
    LevelInfo LvlInfo;
    void OnTriggerEnter(Collider other)
    {
        LvlInfo.iScore += 1;
        Destroy(gameObject);
    }
    void Start()
    {
        LevelInf = GameObject.Find("LevelInfo");
        LvlInfo = LevelInf.GetComponent<LevelInfo>();
    }

    void Update()
    {
        
    }
}
