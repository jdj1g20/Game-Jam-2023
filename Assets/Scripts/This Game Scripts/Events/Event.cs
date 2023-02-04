using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Event
{
    // Variable names must match variables in the JSON.

    // Description to display that describes the event scenario
    // (i.e. The church wants us to sacrifice everyone to rat god. What do we do?)
    public string description;
    // The advisor who will appear on-screen to describe the event
    public string advisor;
    // Sound effect to play while description is read
    public string SFX;

    // The two decisions that appear after the description is read
    public Decision decision1;
    // Description to show on decision1 button
    public string decision1Desc;
    public Decision decision2;
    // Description to show on decision2 button
    public string decision2Desc;


}