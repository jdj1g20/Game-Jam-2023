using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAdvisorScript : MonoBehaviour
{
    [SerializeField]
    EventPlayer eventPlayer;
    [SerializeField]
    TutorialEventPlayer mainEventPlayer;
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Sprite catA, civilA, economyA, foodA, militaryA;
    public bool fadeIn = false;
    public bool fadeOut = false;
    
    public bool spacePressed = false;
    float speed = 0.2f;

    public bool isGeneric = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void AdvisorEnterScene(bool isGeneric, string advisorType)
    {
        Debug.Log("Loading advisor: " + advisorType);
        if (advisorType == "catA") {
            sprite.sprite = catA;
        } else if (advisorType == "militaryA") {
            sprite.sprite = militaryA;
        } else if (advisorType == "economyA") {
            sprite.sprite = economyA;
        } else if (advisorType == "foodA") {
            sprite.sprite = foodA;
        } else {
            sprite.sprite = civilA;
        }

        this.isGeneric = isGeneric;
        // Set advisor to face king
        Debug.Log("Advisor Facing king");
        transform.localScale = new Vector3(8.864027f, 8.034133f, 0.1923054f);
        // Set advisor to active
        gameObject.SetActive(true);
        // Fade in advisor
        fadeIn = true;
        spacePressed = false;
    }

    private void AdvisorEnteredScene()
    {
        // Call eventPlayer to start reading event description
        StartCoroutine(mainEventPlayer.StartInitialEventDescription());
    }

    public void AdvisorLeaveScene()
    {
        Debug.Log("AdvisorLeaveScene");
        // Set advisor to face away from king
        transform.localScale = new Vector3(-8.864027f, 8.034133f, 0.1923054f);
        // Start fade out
        spacePressed = false;
        fadeOut = true;    
    }

    private void AdvisorLeftScene()
    {
        // Set advisor to inactive
        gameObject.SetActive(false);
        // End of scene
        if (isGeneric) eventPlayer.EventEnded();
        else mainEventPlayer.EventEnded();
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
                sprite.color = new Color(1, 1, 1, 1);
                spacePressed = false;
                fadeIn = false;
                Debug.Log("Advisor Entered Scene (space)");
                AdvisorEnteredScene();
            }
            else
            {
                // Slowly fade in
                sprite.color = new Color(sprite.color.r + speed * Time.deltaTime, sprite.color.g + speed * Time.deltaTime, sprite.color.b + speed * Time.deltaTime, sprite.color.a + speed * Time.deltaTime);
                if (sprite.color.a >= 1 && sprite.color.r >= 1 && sprite.color.b >= 1 && sprite.color.g >= 1)
                {
                    fadeIn = false;
                    Debug.Log("Advisor Entered Scene");
                    AdvisorEnteredScene();
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
                sprite.color = new Color(0, 0, 0, 0);
                spacePressed = false;
                fadeOut = false;
                Debug.Log("Advisor Left Scene (space)");
                AdvisorLeftScene();
            }
            else
            {
                // Slowly fade out
                sprite.color = new Color(sprite.color.r - speed * Time.deltaTime, sprite.color.b - speed * Time.deltaTime, sprite.color.g - speed * Time.deltaTime, sprite.color.a - speed * Time.deltaTime);
                if (sprite.color.a <= 0 && sprite.color.r <= 0 && sprite.color.b <= 0 && sprite.color.g <= 0)
                {
                    fadeOut = false;
                    Debug.Log("Advisor Left Scene");
                    AdvisorLeftScene();
                }
            }
        }
    }
}
