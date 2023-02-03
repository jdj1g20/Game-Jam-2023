using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TutorialButton2HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    SpriteRenderer military, economy, diplomacy, approval, food;
    [SerializeField]
    GenericEventPlayer eventPlayer;
    [SerializeField]
    TutorialEventPlayer mainEventPlayer;
    [SerializeField]
    TutorialGameLoop mainGameLoopScript;
    
    [SerializeField]
    TutorialButtonSelectScript buttonSelectScript;
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Mouse Enter Button2");
        if (mainGameLoopScript.playingMainEvent) {
            EventMain currentEvent = mainEventPlayer.currentEvent;
            if (!mainEventPlayer.finalEvent) {
                string stat1 = currentEvent.decision2.stat1;
                string stat2 = currentEvent.decision2.stat2;
                ChangeStatColourYellow(CheckStat(stat1), CheckStat(stat2));
            }
            
        } else {
            Event currentEvent = eventPlayer.currentEvent;
            string stat1 = currentEvent.decision2.stat1;
            string stat2 = currentEvent.decision2.stat2;
            ChangeStatColourYellow(CheckStat(stat1), CheckStat(stat2));
        }
        
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Mouse Exit Button2");
        if (mainGameLoopScript.playingMainEvent) {
            EventMain currentEvent = mainEventPlayer.currentEvent;
            string stat1 = currentEvent.decision2.stat1;
            string stat2 = currentEvent.decision2.stat2;
            ChangeStatColourWhite(CheckStat(stat1), CheckStat(stat2));
        } else {
            Event currentEvent = eventPlayer.currentEvent;
            string stat1 = currentEvent.decision2.stat1;
            string stat2 = currentEvent.decision2.stat2;
            ChangeStatColourWhite(CheckStat(stat1), CheckStat(stat2));
        }
    }

    private SpriteRenderer CheckStat(string stat) {
        if (stat == "military") {
            return military;
        } else if (stat == "economy") {
            return economy;
        } else if (stat == "diplomacy") {
            return diplomacy;
        } else if (stat == "approval") {
            return approval;
        } else if (stat == "food") {
            return food;
        }
        return null;
    }
    private void ChangeStatColourYellow(SpriteRenderer sprite1, SpriteRenderer sprite2){
        if (sprite1 != null) {
            sprite1.color = Color.yellow;
        }
        if (sprite2 != null) {
            sprite2.color = Color.yellow;
        }
        
    }

    private void ChangeStatColourWhite(SpriteRenderer sprite1, SpriteRenderer sprite2){
        if (sprite1 != null) {
            sprite1.color = Color.white;
        }
        if (sprite2 != null) {
            sprite2.color = Color.white;
        }
    }
}
