using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LootBehaviour : MonoBehaviour
{
    private float itemGetThreshold, randomItemChanceNumber;
    private string gotItem;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void RollItemChance()
    {
        if (randomItemChanceNumber <= itemGetThreshold)
        {
            gotItem = ItemsScript.Instance.itemTypesArray[Random.Range(0, 2)];
            ItemsScript.Instance.itemDict[gotItem] += 1;
        }
        else
        {
            gotItem = null;
        }
    }

    // Update is called once per frame
    void OnEnable()
    {
        itemGetThreshold = 100F;
        randomItemChanceNumber = Random.Range(0F, 100F);
        RollItemChance();
        GameManager.Instance.lootText.text = gotItem != null ? "¡Has obtenido " + gotItem + "!" : "No has encontrado nada :(";
    }
}
