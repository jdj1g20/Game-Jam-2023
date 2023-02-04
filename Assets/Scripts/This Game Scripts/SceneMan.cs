using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public static class  SceneMan{
  public static void loadScene(string Name){
    Debug.Log("in load scene");
    Debug.Log(Name);
    SceneManager.LoadScene(Name);

  }
public static void ExitGame(){
  Application.Quit();
}
}
