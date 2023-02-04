using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class StatNumbersScript : MonoBehaviour
{
    [SerializeField]
    GameObject military, economy, diplomacy, approval, food;
    // TextMeshProUGUI militaryT, economyT, diplomacyT, approvalT;
    // Start is called before the first frame update
    void Start()
    {
        military.SetActive(false);
        economy.SetActive(false);
        diplomacy.SetActive(false);
        approval.SetActive(false);
        food.SetActive(false);
        // militaryT = military.GetComponent<TextMeshProUGUI>();
        // economyT = economy.GetComponent<TextMeshProUGUI>();
        // diplomacyT = diplomacy.GetComponent<TextMeshProUGUI>();
        // approvalT = approval.GetComponent<TextMeshProUGUI>();
        // militaryT.SetText("5");
        // economyT.SetText("5");
        // diplomacyT.SetText("5");
        // approvalT.SetText("5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        Debug.Log("Activating Stat Numbers");
        military.SetActive(true);
        economy.SetActive(true);
        diplomacy.SetActive(true);
        approval.SetActive(true);
        food.SetActive(true);
    }

    void OnMouseExit() {
        Debug.Log("Deactivating Stat Numbers");
        military.SetActive(false);
        economy.SetActive(false);
        diplomacy.SetActive(false);
        approval.SetActive(false); 
        food.SetActive(false);  
    }
}
