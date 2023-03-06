using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int difficultyLevel;
    public float morale;
    public int moraleBonus;
    public int enemiesLeft;
    public GameObject[] spawnedEntities;
    public TMP_Text moraleText;
    public TMP_Text enemiesLeftText;
    public TMP_Text gameOverText;
    public TMP_Text victoryText;

    private bool isGameLoopRunning;

    public static GameManager Instance { get; private set; }

    //prevenimos m�ltiples copias/instancias
    void Awake()
    {
    difficultyLevel = 1;
    isGameLoopRunning = true;
    morale = 100 + moraleBonus;
    enemiesLeft = 10 * difficultyLevel;
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnedEntities = new GameObject[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameLoopRunning) {
            morale -= Time.deltaTime;
        }
        moraleText.text = "Morale: " + Mathf.FloorToInt(morale);
        enemiesLeftText.text = "Enemies left: " + enemiesLeft;
        if (morale <= 0) {
            morale = 0;
            isGameLoopRunning = false;
            gameOverText.enabled = true;
        }
        if (enemiesLeft == 0) {
            isGameLoopRunning = false;
            victoryText.enabled = true;
        }
    }
}
