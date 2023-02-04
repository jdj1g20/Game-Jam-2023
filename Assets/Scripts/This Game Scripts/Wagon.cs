using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wagon: MonoBehaviour{
  public bool Beaver;
  public bool Traveler;
  public int Travel;
  public int Lives;
  public Sprite WagonSprite;
  public string spriteString;

public Wagon(){
    Beaver = true;
    Traveler = false;
    Travel = 0;
    Lives = 4;
    spriteString = "Wagon1";

}

public void killBeaver(){
  Beaver = false;
}
public void addTraveler(){
    Traveler = true;
    Lives = Lives +1;
    //add change sprite here
}

public int calcLives(int Change){
   Lives = Lives - Change;
  if (Lives < 1){
    return -1;
  }
    return 0;
}

}
