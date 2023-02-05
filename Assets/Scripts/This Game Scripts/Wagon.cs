using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wagon: MonoBehaviour{
  public bool Beaver;
  public bool Traveler;
  public int Travel;
  public int Lives;
  public Sprite WagonSprite1, WagonSprite2, WagonSprite3, WagonSprite4;
  public string spriteString;
  public Inventory inventory;
  public SpriteRenderer spriterender;
  public GameObject travelerObj;
public Wagon(){
    Beaver = true;
    Traveler = false;
    Travel = 0;
    Lives = 4;
    spriteString = "Wagon1";
}
void Start(){
  chooseSprite();
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
   int newV = Lives + Change;

  if (newV < 0){
    return -1;
  }
  Lives = Lives + Change;
  chooseSprite();
    return 0;
}

public void chooseSprite(){
  int life = Lives;
  travelerObj.SetActive(Traveler);
  if(Traveler){
    life = life -1;
   }

  switch (life){
    case 1:
    spriterender.sprite = WagonSprite1;
    break;
    case 2:
    spriterender.sprite = WagonSprite2;
    break;
    case 3:
    spriterender.sprite = WagonSprite3;
    break;
    case 4:
    spriterender.sprite = WagonSprite4;
    break;
    default:
    spriterender.sprite = WagonSprite1;
    break;

  }



}

}
