using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class  Menu: MonoBehaviour{
  public void loadShop(){
    SceneMan.loadScene("Shop");
  }
  public void loadEnd(){
    SceneMan.loadScene("EndScreen");
  }
  public void LoadMenu(){
    SceneMan.loadScene("StartMenu");
  }
}
