using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class intro : MonoBehaviour{
    private TextMeshProUGUI text;
    private bool spaceDetected = false;
    public float speed = 0.00f;
    public GameObject continueButton;

    public IEnumerator PlayIntro()
    {
      string textToDisplay = "You are a rat cowboy traveling with your family to the great city of Mouseoury from your hometown of Orato.\n You are traveling with your ratson Ratz your ratwife Ratefer and your ratmom Ratmom \n you will need some food for the journey, tools to fix the wagon, bullets to deal with situations and money in the form of the glorious Cheesecoin.";
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
