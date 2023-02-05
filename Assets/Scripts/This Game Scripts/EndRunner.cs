using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndRunner : MonoBehaviour
{
  public endv initialTextBoxText;
  public GameObject continueButton;
  void Start() {
    continueButton.SetActive(false);
    StartCoroutine(initialTextBoxText.PlayEnd());
  }

  public void onClickContinune(){
    SceneMan.loadScene("StartMenu");
  }

}
