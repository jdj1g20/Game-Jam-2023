using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpositionFadeScript : MonoBehaviour
{
    [SerializeField]
    Image panelImage, scrollImage;
    [SerializeField]
    TextMeshProUGUI expText;
    [SerializeField]
    ExpositionTextRevealScript textRevealScript;
    [SerializeField]
    GameObject scroll;
    [SerializeField]
    MainGameLoopScript mainGameLoopScript;
    
    string expositionText = "";

    public bool fadeIn = false;
    public bool fadeOut = false;
    
    public bool spacePressed = false;
    float speed = 0.1f;
    
    public void StartExposition(string expositionText) {
        Debug.Log("Starting exposition fade in: " + expositionText);
        expText.text = "";
        this.expositionText = expositionText; 
        gameObject.SetActive(true);
        scroll.SetActive(true);
        // Fade in advisor
        fadeIn = true;
        spacePressed = false;
    }

    private void ExpositionFadedIn() {
        Debug.Log("Exposition faded in, starting text reveal");
        // start scroll text
        StartCoroutine(StartTextDisplay());
        
    }

    private IEnumerator StartTextDisplay() {
        yield return null;
        StartCoroutine(textRevealScript.NewTextToDisplay(expositionText));
    }

    public void EndExposition() {
        // Start fade out
        spacePressed = false;
        fadeOut = true;    
    }

    private void ExpositionFadedOut() {
        // Set advisor to inactive
        expositionText = "";
        gameObject.SetActive(false);
        scroll.SetActive(false);
        mainGameLoopScript.FinishedHidingExposition();
    }
    // Update is called once per frame
    void Update()
    {
        // When space is detected, set spacePressed to true
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Detected Space Press");
            spacePressed = true;
        }
        // If fading in check if space has been pressed
        if (fadeIn)
        {
            //Debug.Log("Fading in");
            if (spacePressed)
            {
                // Skip to faded in
                panelImage.color = new Color(0, 0, 0, 1);
                scrollImage.color = new Color(1, 1, 1, 1);
                expText.color = new Color(0, 0, 0, 1);
                spacePressed = false;
                fadeIn = false;
                Debug.Log("Exposition Faded In (space)");
                ExpositionFadedIn();
            }
            else
            {
                // Slowly fade in
                panelImage.color = new Color(panelImage.color.r - speed * Time.deltaTime, panelImage.color.g - speed * Time.deltaTime, panelImage.color.b - speed * Time.deltaTime, panelImage.color.a + speed * Time.deltaTime);
                scrollImage.color = new Color(scrollImage.color.r + speed * Time.deltaTime, scrollImage.color.g + speed * Time.deltaTime, scrollImage.color.b + speed * Time.deltaTime, scrollImage.color.a + speed * Time.deltaTime);
                expText.color = new Color(expText.color.r - speed * Time.deltaTime, expText.color.g - speed * Time.deltaTime, expText.color.b - speed * Time.deltaTime, expText.color.a + speed * Time.deltaTime);

                if (panelImage.color.a >= 1 && panelImage.color.r <= 0 && panelImage.color.b <= 0 && panelImage.color.g <= 0)
                {
                    fadeIn = false;
                    Debug.Log("Exposition Faded In");
                    ExpositionFadedIn();
                }
            }
        }
        // If fading out check if space has been pressed
        else if (fadeOut)
        {
            //Debug.Log("Fade out is spacepressed?: " + spacePressed);
            if (spacePressed)
            {
                // Skip to faded out
                panelImage.color = new Color(0, 0, 0, 0);
                scrollImage.color = new Color(0, 0, 0, 0);
                expText.color = new Color(0, 0, 0, 0);
                spacePressed = false;
                fadeOut = false;
                Debug.Log("Exposition Faded Out (space)");
                ExpositionFadedOut();
            }
            else
            {
                // Slowly fade out
                panelImage.color = new Color(panelImage.color.r - speed * Time.deltaTime, panelImage.color.b - speed * Time.deltaTime, panelImage.color.g - speed * Time.deltaTime, panelImage.color.a - speed * Time.deltaTime);
                scrollImage.color = new Color(scrollImage.color.r - speed * Time.deltaTime, scrollImage.color.b - speed * Time.deltaTime, scrollImage.color.g - speed * Time.deltaTime, scrollImage.color.a - speed * Time.deltaTime);
                expText.color = new Color(expText.color.r - speed * Time.deltaTime, expText.color.b - speed * Time.deltaTime, expText.color.g - speed * Time.deltaTime, expText.color.a - speed * Time.deltaTime);

                if (panelImage.color.a <= 0 && panelImage.color.r <= 0 && panelImage.color.b <= 0 && panelImage.color.g <= 0)
                {
                    fadeOut = false;
                    Debug.Log("Exposition Faded Out");
                    ExpositionFadedOut();
                }
            }
        }
    }
}
