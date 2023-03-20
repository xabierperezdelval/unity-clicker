using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour

{
    public GameObject lightEnemy;
    public GameObject hardEnemy;
    public GameObject healthBar;
    public GameObject spawnPos1;
    public GameObject spawnPos2;
    public GameObject spawnPos3;
    private GameObject[] spawnPositions;
    [SerializeField] public bool[] spawnPositionsBusy;
    private float hardEnemyChance;
    public int spawnPositionNumber;
    [SerializeField] public float spawnTimer;

    //creamos una instancia para manejar los par�metros desde otros objetos
    public static EnemySpawner Instance { get; private set; }

    //prevenimos m�ltiples copias/instancias
    void Awake()
    {
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
        hardEnemyChance = 12.5F * GameManager.Instance.difficultyLevel;
        spawnPositionsBusy = new bool[] { false, false, false };
        spawnPositions = new GameObject[] { spawnPos1, spawnPos2, spawnPos3 };
        spawnTimer = Random.Range(4F, 7F);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnEnemy();
        }
    }

    private GameObject getSpawnPoint(int randomSpawnPointNumber)
    {
        switch (randomSpawnPointNumber)
        {
            case 0:
                return spawnPositions[0];
            case 1:
                return spawnPositions[1];
            case 2:
                return spawnPositions[2];
            default:
                return null;
        }
    }

    private void spawnEnemy()
    {
        float randomHardEnemyChanceNumber = Random.Range(0F, 100F);
        int randomSpawnPointNumber = Random.Range(0, 3);
        if (randomHardEnemyChanceNumber <= hardEnemyChance)
        {
            if (!spawnPositionsBusy[randomSpawnPointNumber])
            {
                GameManager.Instance.spawnedEntities[randomSpawnPointNumber] = Instantiate(hardEnemy, getSpawnPoint(randomSpawnPointNumber).transform.position, Quaternion.identity);
                GameManager.Instance.spawnedHealthBar[randomSpawnPointNumber] = Instantiate(healthBar, new Vector3(getSpawnPoint(randomSpawnPointNumber).transform.position.x, getSpawnPoint(randomSpawnPointNumber).transform.position.y + 5, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("EnemyCanvas").transform);
                spawnPositionNumber = randomSpawnPointNumber;
                spawnPositionsBusy[randomSpawnPointNumber] = true;
                spawnTimer = Random.Range(4F, 7F) - 0.3F;
            }
        }
        else
        {
            if (!spawnPositionsBusy[randomSpawnPointNumber])
            {
                GameManager.Instance.spawnedEntities[randomSpawnPointNumber] = Instantiate(lightEnemy, getSpawnPoint(randomSpawnPointNumber).transform.position, Quaternion.identity);
                GameManager.Instance.spawnedHealthBar[randomSpawnPointNumber] = Instantiate(healthBar, new Vector3(getSpawnPoint(randomSpawnPointNumber).transform.position.x, getSpawnPoint(randomSpawnPointNumber).transform.position.y + 5, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("EnemyCanvas").transform);
                spawnPositionNumber = randomSpawnPointNumber;
                spawnPositionsBusy[randomSpawnPointNumber] = true;
                spawnTimer = Random.Range(4F, 7F) - 0.3F;
            }
        }
    }
}
