using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameObject LevelInf;
    GameObject CollectAudioObj;
    LevelInfo LvlInfo;
    AudioSource CollectSoundSource;
    void OnTriggerEnter(Collider other)
    {
        LvlInfo.iScore += 1;
        CollectSoundSource.Play();
        Destroy(gameObject);
    }
    void Start()
    {
        LevelInf = GameObject.Find("LevelInfo");
        CollectAudioObj = GameObject.Find("CoinCollectAud");
        LvlInfo = LevelInf.GetComponent<LevelInfo>();
        CollectSoundSource = CollectAudioObj.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
