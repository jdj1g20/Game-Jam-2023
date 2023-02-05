using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UILoader: MonoBehaviour{
  Inventory inventory;
  public Wagon wagon;
  public TextMeshProUGUI MonDisplay;
  public TextMeshProUGUI FoodDisplay;
  public TextMeshProUGUI ToolsDisplay;
  public TextMeshProUGUI BulletsDisplay;
  public TextMeshProUGUI LivesDisplay;
void Start(){
  if(Inventory.Instance != null){
    inventory = Inventory.Instance;
  }else{
  }

}


  void Update(){
       MonDisplay.text = inventory.Money.ToString();
       FoodDisplay.text = inventory.Food.ToString();
       ToolsDisplay.text = inventory.Tools.ToString();
       BulletsDisplay.text = inventory.Bullets.ToString();
       LivesDisplay.text = wagon.Lives.ToString();
  }
}
