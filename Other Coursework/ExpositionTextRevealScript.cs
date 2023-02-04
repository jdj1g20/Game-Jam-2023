using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExpositionTextRevealScript : MonoBehaviour
{
    
    [SerializeField]
    ExpositionFadeScript expositionFadeScript;
    [SerializeField]
    MainGameLoopScript mainGameLoopScript;
    private TextMeshProUGUI text;
    private bool spaceDetected = false;

    public IEnumerator NewTextToDisplay(string textToDisplay)
    {
        Debug.Log("Starting to reveal exposition text");
        spaceDetected = false;

        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = textToDisplay;

        int totalVisibleChars = text.text.Length;


        text.maxVisibleCharacters = 0;


        for (int visibleCount = 1; visibleCount <= totalVisibleChars; visibleCount++)
        {
            text.maxVisibleCharacters = visibleCount;

            if (spaceDetected)
            {
                text.maxVisibleCharacters = totalVisibleChars;
                break;

            }
            yield return new WaitForSeconds(0.08f);

        }
        Debug.Log("Text Ended");
        // Text Ended
        mainGameLoopScript.FinishedReadingExposition();
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("ExpositionText detected space");
            spaceDetected = true;
        }
    }


}
