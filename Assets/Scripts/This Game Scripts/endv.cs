using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endv : MonoBehaviour{
    private TextMeshProUGUI text;
    private bool spaceDetected = false;
    public float speed = 0.00f;
    public GameObject continueButton;

    public IEnumerator PlayEnd()
    {
      string textToDisplay = "You have done it, you are finally here so you can finaly rob that bank you came here to rob. You manage to rob the bank and 2 more becue you are a good rat, and thats what rats do.";
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
            yield return new WaitForSeconds(speed);

        }
        Debug.Log("Text Ended");
        continueButton.SetActive(true);
        //
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spaceDetected = true;
        }
    }


}
