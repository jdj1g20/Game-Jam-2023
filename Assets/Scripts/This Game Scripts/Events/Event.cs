using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Event
{
    // Variable names must match variables in the JSON.

    public string sceneName;
    // Description to display that describes the event scenario
    // (i.e. The church wants us to sacrifice everyone to rat god. What do we do?)
    public string description;
    // Background image to display
    public string background;

    // The four decisions that appear after the description is read
    public Option decision1;
    // Description to show on decision1 button
    public string decision1Desc;
    public Option decision2;
    // Description to show on decision2 button
    public string decision2Desc;
    public Option decision3;
    
    // Description to show on decision3 button
    public string decision3Desc;
    public Option decision4;
    // Description to show on decision4 button
    public string decision4Desc;


}