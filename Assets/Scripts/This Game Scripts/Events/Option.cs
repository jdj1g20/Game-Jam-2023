using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option
{
    // Variable names must match variables in the JSON.

    
    // Resource required for option
    public string resource;
    // Amount to change stat1
    public int resourceAmount;
    
    public Outcome outcomeSuccess;
    public Outcome outcomeFailure;

}
