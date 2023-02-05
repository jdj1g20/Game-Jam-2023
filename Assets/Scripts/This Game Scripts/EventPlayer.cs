using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EventPlayer : MonoBehaviour
{
  public GameObject invobj;

    [SerializeField]
    private GameObject initialTextBox, option1, option2, option3, option4, continueButton;
    [SerializeField]
    private TextRevealScript initialTextBoxText;
    [SerializeField]
    private TextMeshProUGUI option1Text, option2Text, option3Text, option4Text;
    public Event currentEvent;
    public SpriteLoader sprtldr;

    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private Wagon wagon;
    public bool playingOutcome = false;
    private bool gameOver = false;
    private bool dayEnd = false;
    void Start() {
        if(Inventory.Instance != null){
          inventory = Inventory.Instance;
        }
        initialTextBox.SetActive(false);
        option1.SetActive(false);
        option2.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
        continueButton.SetActive(false);
    }
    public void PlayEvent(Event eventToPlay) {
        dayEnd = false;
        playingOutcome = false;
        Debug.Log("Playing event " + eventToPlay.description);
        currentEvent = eventToPlay;
        initialTextBox.SetActive(true);

        string backgroundText = eventToPlay.description;
        //sprtldr.SetScene("Traveler");//eventToPlay.sceneName);
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

                continueButton.SetActive(true);
            }
        } else if (dayEnd) {
            Debug.Log("Day end text finished");
            if (gameOver) {
                Debug.Log("GameOver Screen");
            } else {
                Debug.Log("Start next day");

                continueButton.SetActive(true);
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
    public void ContinueSelect() {
        Debug.Log("Selected continue button");
        if (dayEnd) {
            Debug.Log("Starting next event");

        } else {

            continueButton.SetActive(false);
            // change background to campfire
            PlayDayEnd();
        }


    }

    private void PlayDayEnd() {
        Debug.Log("Starting Day End");
        dayEnd= true;
        int peopleAlive = wagon.Lives;
        Debug.Log("People Alive: " + peopleAlive);

        string dayEndText = "";

        // Check if someone dies of dysentery
        float dysenteryChance = Random.Range(0,1f);
        if (dysenteryChance < 0.05f) {
            Debug.Log("O no someone died of dysentery");
            wagon.Lives -= 1;
            if (wagon.Lives > 0) {
                dayEndText += "You died of dysentery. Good job.";
                gameOver = true;
                StartCoroutine(initialTextBoxText.NewTextToDisplay(dayEndText));
                return;
            } else {
                dayEndText += "One of your family members died of dysentery in the night.\n";
            }
        } else {
            Debug.Log("No-one died of dysentery");
            dayEndText += "No-one died of dysentery\n";
        }

        if (inventory.calcFood(wagon.Lives * -1) == -1) {
            if (wagon.Lives > 0) {
                dayEndText += "Your family ate all your food, but didn't have enough. Someone starved to death in the night.\n";
            } else {
                dayEndText += "You've run out of food and starved to death in the night. Good job.\n";
                gameOver = true;
                StartCoroutine(initialTextBoxText.NewTextToDisplay(dayEndText));
                return;
            }

        } else {
            dayEndText += "Your family ate " + wagon.Lives + " food.\n";
        }

        if (wagon.Traveler) {
            if (inventory.calcFood(1) == -1) {
                dayEndText += "The traveller had no food and starved to death.\n";
            } else {
                dayEndText += "The traveller ate 1 food\n";
            }
        }
        StartCoroutine(initialTextBoxText.NewTextToDisplay(dayEndText));
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
