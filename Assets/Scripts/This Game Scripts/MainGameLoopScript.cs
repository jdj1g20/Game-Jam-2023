using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MainGameLoopScript : MonoBehaviour
{
    public TextAsset eventsJSON;

    Events events;

    List<Event> eventsList;

    public int eventNo = 0;

    public EventPlayer eventPlayer;



    // Start is called before the first frame update
    void Start()
    {
        StartGameLoop();
    }

   

    private void StartGameLoop() {


        //expositionFadeScript.EndExposition();
        Debug.Log("Starting Main Game Loop");


        Debug.Log("Importing Events");
        events = EventJSONReader.GenerateEventsFromJSON(eventsJSON);

        // Play back story
        

        eventsList = events.events;
        for (int i=0; i < eventsList.Count; i++) {
            Event temp = eventsList[i];
            int random = Random.Range(i, eventsList.Count);
            eventsList[i] = eventsList[random];
            eventsList[random] = temp;
        }
      
    

    }

}