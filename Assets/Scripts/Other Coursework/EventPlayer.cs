using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EventPlayer : MonoBehaviour 

{
    public abstract void PlayEvent(Event eventToPlay);
    public abstract void RevealEventChoices();
    public abstract IEnumerator StartInitialEventDescription();
    public abstract void TextEnded();

    public abstract void EventEnded();

}
