using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] buttons = new GameObject[3];

    private void Awake()
    {
        
    }
    void Start()
    {

        if (ItemsScript.Instance.itemDict["Vial de invencibilidad"] > 0) 
            {
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = buttons[0].GetComponentInChildren<TextMeshProUGUI>().text + " (" + ItemsScript.Instance.itemDict["Vial de invencibilidad"] + ")";
            }
        if (ItemsScript.Instance.itemDict["Poción de berserker"] > 0)
        {
                buttons[1].GetComponent<Button>().interactable = true;
                buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = buttons[1].GetComponentInChildren<TextMeshProUGUI>().text + " (" + ItemsScript.Instance.itemDict["Poción de berserker"] + ")";
            }
        if (ItemsScript.Instance.itemDict["Cuerno de hidromiel"] > 0)
        {
                buttons[2].GetComponent<Button>().interactable = true;
                buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = buttons[2].GetComponentInChildren<TextMeshProUGUI>().text + " (" + ItemsScript.Instance.itemDict["Cuerno de hidromiel"] + ")";
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
