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
    [SerializeField]
    private Wagon wagon;
    public bool playingOutcome = false;
    private bool gameOver = false;
    void Start() {
        initialTextBox.SetActive(false);
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
    }
    public void PlayEvent(Event eventToPlay) {
        playingOutcome = false;
        Debug.Log("Playing event " + eventToPlay.description);
        currentEvent = eventToPlay;
        initialTextBox.SetActive(true);
        
        string backgroundText = eventToPlay.description;
        Debug.Log("Calling initial text box text with " + backgroundText);
        StartCoroutine(initialTextBoxText.NewTextToDisplay(backgroundText));

    }

    public void TextEnded() {
        if (playingOutcome) {
            playingOutcome = false;
            Debug.Log("Finished reading outcome");
            if (gameOver) {
                Debug.Log("GameOver screen");
            } else
            {
                Debug.Log("Next event");
            }
        } else {
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
        int result;
        switch (option.resource)
        {
            case "Food" :
                Debug.Log("Food case");
                Debug.Log("food amount: " + inventory.Food);
                result = inventory.calcFood(resourceAmount * -1);
                if (result == 1 || result == -1) {
                    Debug.Log("Failure outcome");
                    PlayOutcome(option.outcomeFailure);
                } else {
                    Debug.Log("Success outcome, new food: " + inventory.Food);
                    PlayOutcome(option.outcomeSuccess);
                }
                break;
            case "Money" :
                Debug.Log("Money case");
                Debug.Log("money amount: " + inventory.Money);
                result = inventory.calcMoney(resourceAmount * -1);
                if (result == 1 || result == -1) {
                    Debug.Log("Failure outcome");
                    PlayOutcome(option.outcomeFailure);
                } else {
                    Debug.Log("Success outcome, new money: " + inventory.Money);
                    PlayOutcome(option.outcomeSuccess);
                }
                break;
            case "Bullets" :
                Debug.Log("Bullets case");
                Debug.Log("bullets amount: " + inventory.Bullets);
                result = inventory.calcBullets(resourceAmount * -1);
                if (result == 1 || result == -1) {
                    Debug.Log("Failure outcome");
                    PlayOutcome(option.outcomeFailure);
                } else {
                    Debug.Log("Success outcome, new bullets: " + inventory.Bullets);
                    PlayOutcome(option.outcomeSuccess);
                }
                break;
            case "Tools" :
                Debug.Log("Tools case");
                Debug.Log("tools amount: " + inventory.Tools);
                result = inventory.calcTools(resourceAmount * -1);
                if (result == 1 || result == -1) {
                    Debug.Log("Failure outcome");
                    PlayOutcome(option.outcomeFailure);
                } else {
                    Debug.Log("Success outcome, new tools: " + inventory.Tools);
                    PlayOutcome(option.outcomeSuccess);
                }
                break;
            case "Child" :
                Debug.Log("Child case");
                Debug.Log("lives amount: " + wagon.Lives);
                
                if (wagon.Lives < 4) {
                    Debug.Log("Failure outcome");
                    PlayOutcome(option.outcomeFailure);
                } else {
                    Debug.Log("Success outcome");
                    PlayOutcome(option.outcomeSuccess);
                }
                break;
            case "Comedy" :
                Debug.Log("Comedy case");
                Debug.Log("lives amount: " + wagon.Lives);

                if (wagon.Lives < 2) {
                    Debug.Log("Failure outcome");
                    PlayOutcome(option.outcomeFailure);
                } else {
                    Debug.Log("Success outcome");
                    PlayOutcome(option.outcomeSuccess);
                }
                break;
            default:
                Debug.Log("Ahh things havev gone rong case");
                break;
        }
    }

    private void PlayOutcome(Outcome outcome) {
        playingOutcome = true;
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
        string outcomeText = outcome.finalDescription;

        // Changing lives
        int resultLives = wagon.calcLives(outcome.someoneDies);
        Debug.Log(outcome.someoneDies + " people die");
        Debug.Log("lives before event: " + wagon.Lives);
        if (resultLives == 0) {
            Debug.Log("Still got alive peeps");
        } else {
            Debug.Log("Everyone is ded");
            gameOver = true;
        }
        Debug.Log("lives after event: " + wagon.Lives);
        StartCoroutine(initialTextBoxText.NewTextToDisplay(outcomeText));

        
        
        
    }

}
