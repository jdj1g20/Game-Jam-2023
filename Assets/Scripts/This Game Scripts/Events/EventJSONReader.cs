using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class EventJSONReader
{

    public static Events GenerateEventsFromJSON(TextAsset json)
    {
        Events eventsList = JsonUtility.FromJson<Events>(json.text);
        
        foreach (Event even in eventsList.events)
        {
            //Debug.Log("Found Event: " + even.description);
            //Debug.Log("Event Advisor: " + even.advisor);
            //Debug.Log("Event SFX: " + even.SFX);
            //Debug.Log("Event Decision 1 Button Desc: " + even.decision1Desc);
            //Debug.Log("Event Decision 2 Button Desc: " + even.decision2Desc);

            // Debug.Log("Event Decision 1: " + even.decision1.description);
            // Debug.Log("Event Decision 1 stat1: " + even.decision1.stat1);
            // Debug.Log("Event Decision 1 stat1Amount: " + even.decision1.stat1Amount);
            // Debug.Log("Event Decision 1 stat2: " + even.decision1.stat2);
            // Debug.Log("Event Decision 1 stat2Amount: " + even.decision1.stat2Amount);
            // Debug.Log("Event Decision 1 SFX: " + even.decision1.SFX);

            // Debug.Log("Event Decision 2: " + even.decision2.description);
            // Debug.Log("Event Decision 2 stat1: " + even.decision2.stat1);
            // Debug.Log("Event Decision 2 stat1Amount: " + even.decision2.stat1Amount);
            // Debug.Log("Event Decision 2 stat2: " + even.decision2.stat2);
            // Debug.Log("Event Decision 2 stat2Amount: " + even.decision2.stat2Amount);
            // Debug.Log("Event Decision 2 SFX: " + even.decision2.SFX);
        }
        return eventsList;
    }
}
