using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour{
  public int Bullets;
  public int Food;
  public int Money;
  public int Tools;
  public float Weight;
  public int maxBullets;
  public int maxFood;
  public int maxMoney;
  public int maxTools;

public Inventory(){
  Bullets = 0;
    Food = 0;
    Money = 0;
    Tools = 0;
    Weight = 0.0f;
    maxBullets = 10;
    maxFood = 50;
    maxMoney = 1000;
    maxTools = 10;
}
//returns 0 if ok 1 if over limit and -1 if under limit
public int calcFood(int Change){
   int newV = Food + Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxFood) {
    return 1;
  }else {
    Food =+ Change;
    return 0;
  }
}

public int calcBullets(int Change){
   int newV =  Bullets + Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxBullets) {
    return 1;
  }else {
    Bullets =+ Change;
    return 0;
  }
}

public int calcMoney(int Change){
   int newV =  Money + Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxMoney) {
    return 1;
  }else {
    Money =+ Change;
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
    Tools =+ Change;
        return 0;
  }
}

public bool checkInventory(){
  return calcFood(0)+calcBullets(0)+calcMoney(0)+calcTools(0) == 0;
}


}
