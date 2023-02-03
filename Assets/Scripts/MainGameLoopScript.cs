using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MainGameLoopScript : MonoBehaviour
{
    public TextAsset genericEventsJSON;
    public TextAsset mainEventsJSON;
    public KingdomStatsScript kingdomStats;
    Events genericEvents;
    MainEvents mainEvents;
    List<Event> genericEventsOrder;
    Dictionary<EventMain, int> mainEventsOrder;
    public int eventNo = 0;
    public int mainEventNo = 0;
    
    public int genericEventNo = 0;
    public GenericEventPlayer genericEventPlayer;
    public MainEventPlayer mainEventPlayer;

    public ExpositionFadeScript expositionFadeScript;
    public ExpositionTextRevealScript expositionTextRevealScript;
    public ExpositionTextParser expositionTextParser;

    public GameObject playAgainButton, exitButton;
    string[] exposition;
    public bool playingMainEvent = false;
    public bool playingGenericEvent = false;
    public bool playingIntroduction = false;
    public bool playingGameOverExposition = false;
    public bool displayingIntroduction = false;
    public bool displayingGameOverExposition = false;

    bool finishedIntro = false;
    // Start is called before the first frame update
    void Start()
    {
        StartGameLoop();
    }

   

    private void StartGameLoop() {
        //StartCoroutine(expositionTextRevealScript.NewTextToDisplay("hallo, my nam is jam an i leik potato it is my fav thing in wurld."));
        exposition = expositionTextParser.GetExposition();

        // Hiding buttons
        playAgainButton.SetActive(false);
        exitButton.SetActive(false);

        //expositionFadeScript.EndExposition();
        Debug.Log("Starting Main Game Loop");
        Debug.Log("Setting Start Stats");
        
        kingdomStats.UpdateStatSprites();
        Debug.Log("Importing Generic Events");
        genericEvents = EventJSONReader.GenerateEventsFromJSON(genericEventsJSON);
        //genericEvents = EventJSONReader.GenerateEventsFromJSON(mainEventsJSON);

        // Play back story
        mainEvents = MainEventJSONReader.GenerateEventsFromJSON(mainEventsJSON);
        Debug.Log("mainEvents: " + mainEvents + " mainEvents.mainEvents: " + mainEvents.mainEvents.Count);

        genericEventsOrder = genericEvents.events;
        for (int i=0; i < genericEventsOrder.Count; i++) {
            Event temp = genericEventsOrder[i];
            int random = Random.Range(i, genericEventsOrder.Count);
            genericEventsOrder[i] = genericEventsOrder[random];
            genericEventsOrder[random] = temp;
        }
      
        playingIntroduction = true;

        Debug.Log("Starting Introduction Exposition: " + exposition[0]);
        StartCoroutine(expositionTextRevealScript.NewTextToDisplay(exposition[0]));

    }

    public void FinishedReadingExposition() {
        if (playingIntroduction) {
            Debug.Log("Finished reading introduction, waiting for space");
            StartCoroutine(FinishedIntroductionExp());
            
        } else if (playingGameOverExposition) {
            Debug.Log ("Finished reading game over exposition");
            playingGameOverExposition = false;
            // displayingGameOverExposition = true;
            playAgainButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }

    private IEnumerator FinishedIntroductionExp() {
        yield return new WaitForEndOfFrame();
        playingIntroduction = false;
        displayingIntroduction = true;
    }

    public void FinishedHidingExposition() {
        if (!finishedIntro) {
            finishedIntro = true;
            Debug.Log("Finished fading out introduction, starting main game");
            IntroductionExpositionFinished();

        }
    }

   

    void LateUpdate() {
        if (Input.GetKeyDown("space")) {
            if(displayingIntroduction) {
                Debug.Log("Detected space after finishing introduction text, starting fade out");
                displayingIntroduction = false;
                expositionFadeScript.EndExposition();
            } else if (displayingGameOverExposition) {
                displayingGameOverExposition = false;
                Debug.Log("Game Over Screen");
                // Trigger game over screen
            }
        }
    }
    

    public void IntroductionExpositionFinished() {
        playingMainEvent = true;
        mainEventPlayer.firstEvent = true;
        mainEventPlayer.PlayEvent(mainEvents.mainEvents[mainEventNo]);
        //genericEventPlayer.PlayEvent(mainEvents.events[0]);
        eventNo++;
        
    }

    public void EventEnded() {
        mainEventPlayer.firstEvent = false;
        playingGenericEvent = false;
        playingMainEvent = false;

        string zeroStat = kingdomStats.CheckForZeroStat();
        if (zeroStat == "military") {
            Debug.Log("Starting military gameover");
            playingGameOverExposition = true;
            expositionFadeScript.StartExposition(exposition[1]);
            return;
        } else if (zeroStat == "economy") {
            Debug.Log("Starting economy gameover");
            playingGameOverExposition = true;
            expositionFadeScript.StartExposition(exposition[2]);
            return;
        } else if (zeroStat == "diplomacy") {
            Debug.Log("Starting diplomacy gameover");
            playingGameOverExposition = true;
            expositionFadeScript.StartExposition(exposition[3]);
            return;
        } else if (zeroStat == "approval") {
            Debug.Log("Starting approval gameover");
            playingGameOverExposition = true;
            expositionFadeScript.StartExposition(exposition[4]);
            return;
        } else if (zeroStat == "food") {
            Debug.Log("Starting food gameover");
            playingGameOverExposition = true;
            expositionFadeScript.StartExposition(exposition[5]);
            return;
        }
        // Every 4 events play main story event
        if (eventNo % 4 == 0) {
            Debug.Log("Starting next main event: " + mainEventNo);
            EventMain eventMain = mainEvents.mainEvents[mainEventNo];
            Debug.Log("Found main event: " + eventMain.description);
            playingMainEvent = true;
            if (mainEventNo >= 7) {
                Debug.Log("Final Main Event");
                mainEventPlayer.finalEvent = true;
            }
            mainEventPlayer.PlayEvent(eventMain);
            
    
            // mainEventNo = mainEventsOrder[eventMain];
            // Debug.Log("Setting mainEventNo to " + mainEventNo);
            eventNo ++;
        }
        else {
            Debug.Log("Starting next generic event: " + genericEventNo);
            Event genericEvent = genericEventsOrder[genericEventNo];
            Debug.Log("Found generic event: " + genericEvent.description);
            playingGenericEvent = true;
            genericEventPlayer.PlayEvent(genericEvent);

            genericEventNo ++;
            eventNo ++;
        }
        
    }
    public void FinalEventEnded(int nextMainEvent) {
        playingMainEvent = false;
        Debug.Log("Final event ended");
        Debug.Log("Starting final screen with last exposition of event " + nextMainEvent);
        expositionFadeScript.StartExposition(exposition[nextMainEvent - 9]);
        playingGameOverExposition = true;
    }
}
