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
            Debug.Log("Found Event: " + even.description);
            Debug.Log("Event background: " + even.background);
            Debug.Log("Event Option 1 Button Desc: " + even.decision1Desc);
            Debug.Log("Event Option 2 Button Desc: " + even.decision2Desc);
            Debug.Log("Event Option 3 Button Desc: " + even.decision3Desc);
            Debug.Log("Event Option 4 Button Desc: " + even.decision4Desc);

            Debug.Log("Event Decision 1 resource: " + even.decision1.resource);
            Debug.Log("Event Decision 1 resourceAmount: " + even.decision1.resourceAmount);
            Debug.Log("Event Decision 1 outcome success description: " + even.decision1.outcomeSuccess.finalDescription);
            Debug.Log("Event Decision 1 outcome success someoneDies: " + even.decision1.outcomeSuccess.someoneDies);
            Debug.Log("Event Decision 1 outcome failure description: " + even.decision1.outcomeFailure.finalDescription);
            Debug.Log("Event Decision 1 outcome failure someoneDies: " + even.decision1.outcomeSuccess.someoneDies);

            Debug.Log("Event Decision 2 resource: " + even.decision2.resource);
            Debug.Log("Event Decision 2 resourceAmount: " + even.decision2.resourceAmount);
            Debug.Log("Event Decision 2 outcome success description: " + even.decision2.outcomeSuccess.finalDescription);
            Debug.Log("Event Decision 2 outcome success someoneDies: " + even.decision2.outcomeSuccess.someoneDies);
            Debug.Log("Event Decision 2 outcome failure description: " + even.decision2.outcomeFailure.finalDescription);
            Debug.Log("Event Decision 2 outcome failure someoneDies: " + even.decision2.outcomeSuccess.someoneDies);
            
            Debug.Log("Event Decision 3 resource: " + even.decision3.resource);
            Debug.Log("Event Decision 3 resourceAmount: " + even.decision3.resourceAmount);
            Debug.Log("Event Decision 3 outcome success description: " + even.decision3.outcomeSuccess.finalDescription);
            Debug.Log("Event Decision 3 outcome success someoneDies: " + even.decision3.outcomeSuccess.someoneDies);
            Debug.Log("Event Decision 3 outcome failure description: " + even.decision3.outcomeFailure.finalDescription);
            Debug.Log("Event Decision 3 outcome failure someoneDies: " + even.decision3.outcomeSuccess.someoneDies);

            Debug.Log("Event Decision 4 resource: " + even.decision4.resource);
            Debug.Log("Event Decision 4 resourceAmount: " + even.decision4.resourceAmount);
            Debug.Log("Event Decision 4 outcome success description: " + even.decision4.outcomeSuccess.finalDescription);
            Debug.Log("Event Decision 4 outcome success someoneDies: " + even.decision4.outcomeSuccess.someoneDies);
            Debug.Log("Event Decision 4 outcome failure description: " + even.decision4.outcomeFailure.finalDescription);
            Debug.Log("Event Decision 4 outcome failure someoneDies: " + even.decision4.outcomeSuccess.someoneDies);

           
        }
        return eventsList;
    }
}
