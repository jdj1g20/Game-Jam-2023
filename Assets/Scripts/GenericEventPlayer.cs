using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenericEventPlayer : EventPlayer
{
    [SerializeField]
    AdvisorScript advisor;
    [SerializeField]
    GameObject eventCanvas, eventDescriptionBox, button1, button2;
    [SerializeField]
    TextRevealScript eventText;
    [SerializeField]
    TextMeshProUGUI button1Text, button2Text;

    [SerializeField]
    TextMeshProUGUI eventDescription, button1Description, button2Description;

    public Event currentEvent;
    float waitAfterDescription = 1f;
    public bool initialEventDescriptionPlaying = false;
    public bool currentEventEnded = false;
    public KingdomStatsScript kingdomStats;
    public MainGameLoopScript mainGameLoopScript;

    public AudioClip[] clips;
    public AudioSource sfxPlayer;

    public void start(){
        sfxPlayer = GetComponent<AudioSource>();
    }

    // First method to be called
    public override void PlayEvent(Event eventToPlay)
    {
        // Set up the currentEvent and currentEventEnded variables
        currentEvent = eventToPlay;
        currentEventEnded = false;
        Debug.Log("Starting event");
        // Reveal Advisor
        RevealAdvisor();
    }

    private void RevealAdvisor()
    {
        Debug.Log("Revealing Advisor");
        // Set advisor to currentEvent.advisor
        advisor.AdvisorEnterScene(true, currentEvent.advisor);
    }
    public override IEnumerator StartInitialEventDescription()
    {
        yield return (3f);
        eventCanvas.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        initialEventDescriptionPlaying = true;
        StartCoroutine(eventText.NewTextToDisplay(currentEvent.description, true));
    }

    
    // Late update occurs after update, ensuring advisor doesn't detect space too early
    void LateUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            // If space is pressed and we know the event has ended, make advisor leave
            if (currentEventEnded && mainGameLoopScript.playingGenericEvent)
            {
                Debug.Log("EventPlayer detected space");
                //kingdomStats.UpdateStatSprites();
                eventCanvas.SetActive(false);
                advisor.AdvisorLeaveScene();
            }
        }
    }

    // Called when text has finished writing
    public override void TextEnded()
    {
        if (initialEventDescriptionPlaying)
        {
            // If initial description was writing, reveal decisions
            RevealEventChoices();
        }
        else
        {
            // Otherwise, the event must have ended
            //currentEventEnded = true;
            StartCoroutine(TextEndedYield());
        }
    }

    private IEnumerator TextEndedYield() {
        yield return new WaitForEndOfFrame();
        currentEventEnded = true;
    }

    public override void RevealEventChoices()
    {
        // Reveal buttons and set their text
        initialEventDescriptionPlaying = false;
        button1.SetActive(true);
        button2.SetActive(true);
        button1Text.text = currentEvent.decision1Desc;
        button2Text.text = currentEvent.decision2Desc;
    }

    // If either button is selected, start their respective coroutines
    public void SelectedButton1()
    {
        StartCoroutine(ButtonSelect1(1));
    }

    public void SelectedButton2()
    {
        StartCoroutine(ButtonSelect1(2));
    }

    // First part of ButtonSelect
    public IEnumerator ButtonSelect1(int button) {
        Debug.Log("Chosen Decision " + button);
        // Deactivate buttons
        button1.SetActive(false);
        button2.SetActive(false);
        // Wait a small amount
        yield return new WaitForSeconds(0.3f);
        
        // Call second part with correct decision
        if (button == 1) ButtonSelect2(currentEvent.decision1);
        else ButtonSelect2(currentEvent.decision2);
    }

    // Second part of ButtonSelect
    public void ButtonSelect2(Decision decision)
    {
        // Construct event string 
        string eventString = decision.description + "\n";
        // Add stat numbers to event string
        if (decision.stat1Amount > 0)
        {
            eventString += "Increasing ";
        }
        else
        {
            eventString += "Decreasing ";
        }
        eventString += decision.stat1 + " by " + Mathf.Abs(decision.stat1Amount) + "\n";

        if (decision.stat2Amount > 0)
        {
            eventString += "Increasing ";
        }
        else
        {
            eventString += "Decreasing ";
        }
        eventString += decision.stat2 + " by " + Mathf.Abs(decision.stat2Amount) + "\n";
        //eventString += "Press space to continue...";

        // Play SFX
        for(int i = 0; i < clips.Length; i++){
            if (decision.SFX==clips[i].name){
                sfxPlayer.PlayOneShot(clips[i]);
            }
        }
        // Adjust kingdom stats
        kingdomStats.ChangeStats(decision.stat1, decision.stat1Amount);
        kingdomStats.ChangeStats(decision.stat2, decision.stat2Amount);
        // Update kingdom stats sprites
        kingdomStats.UpdateStatSprites();
        // Start displaying event string 
        StartCoroutine(eventText.NewTextToDisplay(eventString, true));
    }
    
    // Event Ended function for advisor to call
    public override void EventEnded() {
        // Tell main game loop that event has ended
        mainGameLoopScript.EventEnded();
        
    }
}
