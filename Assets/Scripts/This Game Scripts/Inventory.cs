using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
  public TextMeshProUGUI MonDisplay;
  public TextMeshProUGUI FoodDisplay;
  public TextMeshProUGUI ToolsDisplay;
  public TextMeshProUGUI BulletsDisplay;
   public static Inventory Instance;


public Inventory(){
  Bullets = 0;
    Food = 0;
    Money = 100;
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
    Food = Food+ Change;
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
    Bullets =Bullets+ Change;
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
    Money =Money+ Change;
    return 0;
  }
}

public int calcTools(int Change){
   int newV =  Tools + Change;
  if (newV < 0){
    return -1;
  }else if (newV > maxTools) {
    return 1;
  }else {
    Tools =Tools+ Change;
        return 0;
  }
}

public bool checkInventory(){
  return calcFood(0)+calcBullets(0)+calcMoney(0)+calcTools(0) == 0;
}

void Update(){
     MonDisplay.text = Money.ToString();
     FoodDisplay.text = Food.ToString();
     ToolsDisplay.text = Tools.ToString();
     BulletsDisplay.text = Bullets.ToString();
}
void Awake()
    {
        this.InstantiateController();
    }

    private void InstantiateController() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this != Instance) {
            Destroy(this.gameObject);
        }
    }
}
