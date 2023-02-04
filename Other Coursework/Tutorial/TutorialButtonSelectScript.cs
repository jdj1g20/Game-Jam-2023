using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonSelectScript : MonoBehaviour
{

    [SerializeField]
    TutorialEventPlayer mainEventPlayer;
    [SerializeField]
    GenericEventPlayer genericEventPlayer;
    [SerializeField]
    TutorialGameLoop mainGameLoopScript;
    // Start is called before the first frame update

    public void SelectedButton1(){
        Debug.Log("Selected button 1");
        if(mainGameLoopScript.playingMainEvent) {
            Debug.Log("Playing main event");
            StartCoroutine(mainEventPlayer.ButtonSelect1(1));
        } else {
            Debug.Log("Playing generic event");
            StartCoroutine(genericEventPlayer.ButtonSelect1(1));
        }
        
    }
    public void SelectedButton2() {
        Debug.Log("Selected button 1");
        if(mainGameLoopScript.playingMainEvent) {
            Debug.Log("Playing Main event");
            StartCoroutine(mainEventPlayer.ButtonSelect1(2));
        } else {
            Debug.Log("Playing generic event");
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
