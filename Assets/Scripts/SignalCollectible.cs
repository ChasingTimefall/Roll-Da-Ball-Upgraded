using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalObjectiveController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject LevelInf;
    GameObject CollectAudioObj;
    GameObject ObjectiveControllerObj;
    ObjetiveController ObjectiveCtrlScript;
    LevelInfo LvlInfo;
    AudioSource CollectSoundSource;
    void OnTriggerEnter(Collider other)
    {
        LvlInfo.iScore += 1;
        CollectSoundSource.Play();
        ObjectiveCtrlScript.iObjective = 1;
        Destroy(gameObject);
    }
    void Start()
    {
        LevelInf = GameObject.Find("LevelInfo");
        CollectAudioObj = GameObject.Find("CoinCollectAud");
        ObjectiveControllerObj = GameObject.Find("ObjectiveCtrl");
        LvlInfo = LevelInf.GetComponent<LevelInfo>();
        CollectSoundSource = CollectAudioObj.GetComponent<AudioSource>();
        ObjectiveCtrlScript = ObjectiveControllerObj.GetComponent<ObjetiveController>();
    }

    void Update()
    {

    }
}
