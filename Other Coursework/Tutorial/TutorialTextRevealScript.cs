using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialTextRevealScript : MonoBehaviour
{
    [SerializeField]
    EventPlayer eventPlayer;
    [SerializeField]
    TutorialEventPlayer mainEventPlayer;
    private TextMeshProUGUI text;
    private bool spaceDetected = false;

    public IEnumerator NewTextToDisplay(string textToDisplay, bool isGeneric)
    {
        

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
            yield return new WaitForSeconds(0.08f);

        }
        Debug.Log("Text Ended");
        if(isGeneric) eventPlayer.TextEnded();
        else mainEventPlayer.TextEnded();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spaceDetected = true;
        }
    }


}
