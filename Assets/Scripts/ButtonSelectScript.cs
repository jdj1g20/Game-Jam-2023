using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectScript : MonoBehaviour
{

    [SerializeField]
    MainEventPlayer mainEventPlayer;
    [SerializeField]
    GenericEventPlayer genericEventPlayer;
    [SerializeField]
    MainGameLoopScript mainGameLoopScript;
    // Start is called before the first frame update

    public void SelectedButton1(){
        if(mainGameLoopScript.playingMainEvent) {
            StartCoroutine(mainEventPlayer.ButtonSelect1(1));
        } else {
            StartCoroutine(genericEventPlayer.ButtonSelect1(1));
        }
        
    }
    public void SelectedButton2() {
        if(mainGameLoopScript.playingMainEvent) {
            StartCoroutine(mainEventPlayer.ButtonSelect1(2));
        } else {
            StartCoroutine(genericEventPlayer.ButtonSelect1(2));
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
