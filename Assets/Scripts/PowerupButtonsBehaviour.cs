using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class PowerupButtonsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            if (gameObject.name == "invButton")
            {
                Debug.Log("inv selected");
                ItemsScript.Instance.isInvencibilityActive = true;
                ItemsScript.Instance.itemDict["Vial de invencibilidad"] -= 1;
            }
            else if (gameObject.name == "bersButton")
            {
                Debug.Log("bers selected");
                ItemsScript.Instance.isBerserkerActive = true;
                ItemsScript.Instance.itemDict["Poción de berserker"] -= 1;
            }
            else if (gameObject.name == "hornButton")
            {
                Debug.Log("horn selected");
                ItemsScript.Instance.isMeadHornActive = true;
                ItemsScript.Instance.itemDict["Cuerno de hidromiel"] -= 1;
            }
        }
    }
}
