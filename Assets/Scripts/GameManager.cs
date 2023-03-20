using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int difficultyLevel;
    public static int difficultyModifier = -1;
    public float morale;
    public int moraleBonus;
    public int enemiesLeft;
    public GameObject[] spawnedEntities;
    public GameObject[] spawnedHealthBar;
    public GameObject[] spawnedAttackTimers;
    public TMP_Text moraleText;
    public TMP_Text enemiesLeftText;
    public TMP_Text gameOverText;
    public TMP_Text victoryText;
    public TMP_Text lootText;
    public Canvas lootCanvas;

    public bool isGameLoopRunning, invencibleTimerActive, berserkerRageActive;

    public static GameManager Instance { get; private set; }

    //prevenimos m�ltiples copias/instancias
    void Awake()
    {
        if (ItemsScript.Instance.isInvencibilityActive)
        {
            invencibleTimerActive = true;
        }
        if (ItemsScript.Instance.isBerserkerActive)
        {
            berserkerRageActive = true;
        }

        if (ItemsScript.Instance.isMeadHornActive) {
            moraleBonus = 50;
        }
        difficultyModifier++;
        difficultyLevel = 1 + difficultyModifier;
        isGameLoopRunning = true;
        morale = 100 + moraleBonus;
        enemiesLeft = 10 * difficultyLevel;
        if (Instance != null)
            Destroy(Instance);
        Instance = this;
        gameOverText.enabled = false;
        victoryText.enabled = false;
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
        spawnedAttackTimers = new GameObject[3];
        spawnedHealthBar = new GameObject[3];

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameLoopRunning)
        {
            morale -= Time.deltaTime;
        }
        moraleText.text = "Moral: " + Mathf.FloorToInt(morale);
        enemiesLeftText.text = "Quedan " + enemiesLeft + " enemigos";
        if (morale < 0)
        {
            morale = 0;
            isGameLoopRunning = false;
            gameOverText.enabled = true;
            StartCoroutine(ReturnAutoToMenu());
        }
        if (enemiesLeft == 0)
        {
            isGameLoopRunning = false;
            victoryText.enabled = true;
            lootCanvas.gameObject.SetActive(true);
            StartCoroutine(GoToInventoryScreen());
        }
    }

    private IEnumerator ReturnAutoToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuScene");
    }

    private IEnumerator GoToInventoryScreen()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("InventoryScene");
    }
}
