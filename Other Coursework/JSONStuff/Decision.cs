using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Decision
{
    // Variable names must match variables in the JSON.

    // Description to display after option has been chosen
    // (i.e. Everyone dies, but the church is happy)
    public string description;
    // Stat 1 effected by option
    public string stat1;
    // Amount to change stat1
    public int stat1Amount;
    // Stat 2 effected by option
    public string stat2;
    // Amount to change stat2
    public int stat2Amount;
    // Sound effect to play while description is read
    public string SFX;

}
