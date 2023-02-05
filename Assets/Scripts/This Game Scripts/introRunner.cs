using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class introRunner : MonoBehaviour
{
  public intro initialTextBoxText;
  public GameObject continueButton;
  void Start() {
    continueButton.SetActive(false);
    StartCoroutine(initialTextBoxText.PlayIntro());
  }

  public void onClickContinune(){
    SceneMan.loadScene("Shop");
  }

}
