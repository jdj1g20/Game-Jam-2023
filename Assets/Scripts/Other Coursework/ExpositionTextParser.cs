using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpositionTextParser : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset dataFile;
    string[] expositionArray;
    

    public string[] GetExposition() {
        expositionArray = dataFile.text.Split('\n');
        foreach (string exposition in expositionArray) {
            Debug.Log(exposition + ", ");
        }  
        return expositionArray;
    }
}
