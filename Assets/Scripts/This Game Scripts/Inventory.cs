using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory{
  public int Bullets;
  public int Food;
  public int Money;
  public int Tools;
  public float Weight;
  private int maxBullets = 10;
  private int maxFood = 50;
  private int maxMoney = 1000;
  private int maxTools = 10;

//returns 0 if ok 1 if over limit and -1 if under limit
public int calcFood(int Change){
   int newV = Food - Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxFood) {
    return 1;
  }else {
    return 0;
  }
}

public int calcBullets(int Change){
   int newV =  Bullets - Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxBullets) {
    return 1;
  }else {
    return 0;
  }
}

public int calcMoney(int Change){
   int newV =  Money - Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxMoney) {
    return 1;
  }else {
    return 0;
  }
}

public int calcTools(int Change){
   int newV =  Tools - Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxTools) {
    return 1;
  }else {
    return 0;
  }
}

public bool checkInventory(){
  return calcFood(0)+calcBullets(0)+calcMoney(0)+calcTools(0) == 0;
}


}
