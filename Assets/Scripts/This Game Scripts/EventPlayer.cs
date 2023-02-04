using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EventPlayer : MonoBehaviour 
{
    [SerializeField]
    private GameObject initialTextBox, option1, option2, option3, option4;
    [SerializeField]
    private TextRevealScript initialTextBoxText;
    [SerializeField]
    private TextMeshProUGUI option1Text, option2Text, option3Text, option4Text;
    public Event currentEvent;
    
    [SerializeField]
    private Inventory inventory;
    void Start() {
        initialTextBox.SetActive(false);
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
    }
    public void PlayEvent(Event eventToPlay) {
        Debug.Log("Playing event " + eventToPlay.description);
        currentEvent = eventToPlay;
        initialTextBox.SetActive(true);
        
        string backgroundText = eventToPlay.description;
        Debug.Log("Calling initial text box text with " + backgroundText);
        StartCoroutine(initialTextBoxText.NewTextToDisplay(backgroundText));

    }

    public void TextEnded() {
        Debug.Log("Text ended");
        option1Text.text = currentEvent.decision1Desc;
        option2Text.text = currentEvent.decision2Desc;
        option3Text.text = currentEvent.decision3Desc;
        option4Text.text = currentEvent.decision4Desc;
        option1.SetActive(true);
        option2.SetActive(true);
        option3.SetActive(true);
        option4.SetActive(true);
    }

    public void Option1Select() {
        Debug.Log("Selected option 1"); 
        TriggerOption(currentEvent.decision1);  
    }

    public void Option2Select() {
        Debug.Log("Selected option 2");   
        TriggerOption(currentEvent.decision2);
    }
    public void Option3Select() {
        Debug.Log("Selected option 3");   
        TriggerOption(currentEvent.decision3);
    }
    public void Option4Select() {
        Debug.Log("Selected option 4");   
        TriggerOption(currentEvent.decision4);
    }

    private void TriggerOption(Option option) {
        int resourceAmount = option.resourceAmount;
        switch (option.resource)
        {
            case "Food" :
                Debug.Log("Food case");
                if (inventory.Food >= resourceAmount) {
                    
                    inventory.calcFood(resourceAmount);
                    Debug.Log("Have enough food, food is now " + inventory.Food);
                }
                break;
            case "Money" :
                Debug.Log("Money case");
                break;
            case "Bullets" :
                Debug.Log("Bullets case");
                break;
            case "Tools" :
                Debug.Log("Tools case");
                break;
            default:
                Debug.Log("Other case");
                break;
        }
    }

}
