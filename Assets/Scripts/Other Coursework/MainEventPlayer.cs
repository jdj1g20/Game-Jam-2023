using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainEventPlayer : MonoBehaviour
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

    public EventMain currentEvent;
    float waitAfterDescription = 1f;
    public bool initialEventDescriptionPlaying = false;
    public bool currentEventEnded = false;
    public KingdomStatsScript kingdomStats;
    public MainGameLoopScript mainGameLoopScript;
    public int nextMainEvent;
    public bool finalEvent = false;

    public bool firstEvent = true;

    public AudioClip[] clips;
    public AudioClip final;
    public AudioSource sfxPlayer;


    public void start(){
        sfxPlayer = GetComponent<AudioSource>();
    }

    // First method to be called
    public void PlayEvent(EventMain eventToPlay)
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
        advisor.AdvisorEnterScene(false, currentEvent.advisor);
    }
    public IEnumerator StartInitialEventDescription()
    {
        yield return (3f);
        eventCanvas.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        initialEventDescriptionPlaying = true;
        StartCoroutine(eventText.NewTextToDisplay(currentEvent.description, false));
    }

    
    // Late update occurs after update, ensuring advisor doesn't detect space too early
    void LateUpdate()
    {
        if (Input.GetKeyDown("space") )
        {
            // If space is pressed and we know the event has ended, make advisor leave
            if (currentEventEnded && mainGameLoopScript.playingMainEvent)
            {
                Debug.Log("EventPlayer detected space");
                //kingdomStats.UpdateStatSprites();
                eventCanvas.SetActive(false);
                advisor.AdvisorLeaveScene();
            }
        }
    }

    // Called when text has finished writing
    public void TextEnded()
    {
        if (initialEventDescriptionPlaying)
        {
            // If initial description was writing, reveal decisions
            RevealEventChoices();
        }
        else
        {
            // Otherwise, the event must have ended
            StartCoroutine(TextEndedYield());

        }
    }
    private IEnumerator TextEndedYield() {
        yield return new WaitForEndOfFrame();
        currentEventEnded = true;
    }

    public void RevealEventChoices()
    {
        // Reveal buttons and set their text
        initialEventDescriptionPlaying = false;
        button1.SetActive(true);
        button2.SetActive(true);
        button1Text.text = currentEvent.decision1Desc;
        button2Text.text = currentEvent.decision2Desc;
    }

    

    // First part of ButtonSelect
    public IEnumerator ButtonSelect1(int button) {
        Debug.Log("Chosen Decision " + button);
        if(button == 1) nextMainEvent = currentEvent.decision1Next;
        else nextMainEvent = currentEvent.decision2Next;
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

        if (!finalEvent) {
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

            // Play SFX
            
            // Adjust kingdom stats
            kingdomStats.ChangeStats(decision.stat1, decision.stat1Amount);
            kingdomStats.ChangeStats(decision.stat2, decision.stat2Amount);
            // Update kingdom stats sprites
            kingdomStats.UpdateStatSprites();
        }

        for(int i = 0; i < clips.Length; i++){
                if (decision.SFX==clips[i].name){
                    sfxPlayer.PlayOneShot(clips[i]);
                }
            }
        if (firstEvent) {
            eventString += "Press space to continue...";
        }
        

        
        // Start displaying event string 
        StartCoroutine(eventText.NewTextToDisplay(eventString, false));
    }
    
    // Event Ended function for advisor to call
    public void EventEnded() {
        // Tell main game loop that event has ended
        Debug.Log("Setting mainGameLoopScript.mainEventNo to " + nextMainEvent);
        mainGameLoopScript.mainEventNo = nextMainEvent;
        if (!finalEvent) {
            
            mainGameLoopScript.EventEnded();
        } else {
            mainGameLoopScript.FinalEventEnded(nextMainEvent);
        }
        
        
    }    
}
