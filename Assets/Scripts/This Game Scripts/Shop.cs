using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Shop: MonoBehaviour{
  public int Food4S;
  public int Bullets4S;
  public int Tools4S;

  public int FoodCost;
  public int BulletCost;
  public int ToolCost;

  public Sprite foodSpr;
  public Sprite toolSpr;
  public Sprite bulletSpr;
  public string status;

  public Inventory inventory;
  public TextMeshProUGUI StatusBox;


public Shop(){
  Food4S = 30;
  Bullets4S = 5;
  Tools4S = 3;
  FoodCost = 5;
  BulletCost = 5;
  ToolCost = 10;
  status = "";
}

public int BuyFood(int Amount, int Money){ //returns cost of product or -1 if it it to much for the store or 0 if not enough money
  if (Food4S-Amount < 0){
    return -1;
  } else{
    //sucessful buy can occur
    Food4S= Food4S-Amount;
    if (Amount*FoodCost > Money){
      Debug.Log("Too expensive");
      return 0;
    }
    return Amount*FoodCost;
  }
}

public int BuyBullets(int Amount,int Money){ //returns cost of product or -1 if it it to much for the store
  if (Bullets4S-Amount < 0){
    return -1;
  } else{
    //sucessful buy can occur
    Bullets4S= Bullets4S-Amount;
    if (Amount*BulletCost > Money){
      return 0;
    }
    return Amount*BulletCost;
  }
}

public int BuyTools(int Amount,int Money){ //returns cost of product or -1 if it it to much for the store
  if (Tools4S-Amount < 0){
    return -1;
  } else{
    //sucessful buy can occur
    Tools4S= Tools4S-Amount;
    if (Amount*ToolCost > Money){
      return 0;
    }
    return Amount*ToolCost;
  }
}




public void onClickFood(){
  int amnt = 5; //maybe usefull in future
  int outcome =  BuyFood(amnt,inventory.Money);
  if (outcome >0 ){ //sucess
      int a2 = inventory.calcFood(amnt);
      if (a2 == 1){
           status = "You already have enough food >8:(";
           Food4S =  Food4S+amnt; //return item
           Debug.Log("MaxFood");
      }else{
        int a1 = inventory.calcMoney(-outcome);
        if (a1 == -1){
          Debug.Log("OutOfMoney");
          status = "You seem to be out of money, son.";
        }else{
          Debug.Log("Sucess");
          status = "YeeHaw! Thanks for your business!";
        }
      }
  }else{
    status = "Im outa beans!";
  }
}

public void onClickTool(){
  int amnt = 1; //maybe usefull in future
  int outcome =  BuyTools(amnt,inventory.Money);
  if (outcome >0 ){ //sucess
      int a2 = inventory.calcTools(amnt);
      status = "You already have the maximum amount your cart carries";
      if (a2 == 1){
           Tools4S =  Tools4S+amnt; //return item
      }else{
        int a1 = inventory.calcMoney(-outcome);
        if (a1 == -1){
          status = "Out of money";
        }else{
          status = "Hope it serves you well!";
        }
      }
  }else{
    status = "I ain't got no more tools!";
  }
}

public void onClickBullet(){
  int amnt = 1; //maybe usefull in future
  int outcome =  BuyBullets(amnt,inventory.Money);
  if (outcome >0 ){ //sucess
      int a2 = inventory.calcBullets(amnt);
      if (a2 == 1){
          status = "You gonna shoot up an entire town? You got enough bullets mate.";
           Bullets4S =  Bullets4S+amnt; //return item
      }else{
        int a1 = inventory.calcMoney(-outcome);
        if (a1 == -1){
          status = "No Cash, no sale";
        }else{
          status = "Yee, that's what I'm talking about!";
        }
      }
  }else{
    status = "I'm all outta bullets";
  }
}
  public void onClickRat(){
    status = "Squeeeeeek";
  }

  public void onClickDone(){
    Debug.Log("Clicked Done");
    SceneMan.loadScene("MainGame");

  }

  void Update(){
    StatusBox.text = status;
  }
}
