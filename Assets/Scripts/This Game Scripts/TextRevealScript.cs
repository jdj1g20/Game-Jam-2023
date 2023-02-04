using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextRevealScript : MonoBehaviour
{
    [SerializeField]
    EventPlayer eventPlayer;

    private TextMeshProUGUI text;
    private bool spaceDetected = false;

    public IEnumerator NewTextToDisplay(string textToDisplay)
    {
        spaceDetected = false;
        Debug.Log("Playing text " + textToDisplay);   

        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = textToDisplay;

        int totalVisibleChars = text.text.Length;


        text.maxVisibleCharacters = 0;

        spaceDetected = false;
        
        for (int visibleCount = 1; visibleCount <= totalVisibleChars; visibleCount++)
        {
            text.maxVisibleCharacters = visibleCount;

            if (spaceDetected)
            {
                text.maxVisibleCharacters = totalVisibleChars;
                break;

            }
            yield return new WaitForSeconds(0.06f);

        }
        Debug.Log("Text Ended");
        eventPlayer.TextEnded();

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spaceDetected = true;
        }
    }


}
