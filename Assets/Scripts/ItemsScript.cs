using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsScript : MonoBehaviour
{

    const string itemTypes = "Vial de invencibilidad,Poción de berserker,Cuerno de hidromiel";
    public string[] itemTypesArray = itemTypes.Split(',');
    public Dictionary<string, int> itemDict = new Dictionary<string, int>(3);
    public bool isInvencibilityActive, isBerserkerActive, isMeadHornActive;
    public static ItemsScript Instance { get; private set; }

    //prevenimos multiples copias/instancias
    void Awake()
    {
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
        DontDestroyOnLoad(gameObject);
        itemDict.Add(itemTypesArray[0], 0);
        itemDict.Add(itemTypesArray[1], 0);
        itemDict.Add(itemTypesArray[2], 0);
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    void Start()
    {
        isInvencibilityActive = false;
        isBerserkerActive = false;
        isMeadHornActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
