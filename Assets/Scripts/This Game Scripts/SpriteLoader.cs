using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteLoader: MonoBehaviour{
  public int scene;
  public GameObject Snake,Canibal,Racoon;
  private bool SnakeB,CanibalB,RacoonB;

void Start(){
  SetScene(0);
}
public void SetScene(int innScene){

  SnakeB = false;
  CanibalB = false;
  RacoonB = false;
  switch (innScene){
    case 0: // just a double check
    CanibalB = false;
    SnakeB = false;
    RacoonB = false;
    break;
    case 1:
    CanibalB = true;
    break;
    case 3:
    SnakeB = true;
    break;
    case 5:
    RacoonB = true;
    break;
  }
  scene = innScene;
  Canibal.SetActive(CanibalB);
  Racoon.SetActive(RacoonB);
  Snake.SetActive(SnakeB);
}
public void SetScene(string descriptor){

      SnakeB = false;
      CanibalB = false;
      RacoonB = false;
      switch (descriptor){
        case "Traveler":
        CanibalB = true;
        break;
        case "Bandits":
        RacoonB = true;
        break;
        case "Ratter":
        SnakeB = true;
        break;
    }
    Canibal.SetActive(CanibalB);
    Racoon.SetActive(RacoonB);
    Snake.SetActive(SnakeB);
}

}
