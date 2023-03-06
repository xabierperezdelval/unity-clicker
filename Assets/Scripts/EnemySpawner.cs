using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour

{
    public GameObject lightEnemy;
    public GameObject hardEnemy;
    public GameObject spawnPos1;
    public GameObject spawnPos2;
    public GameObject spawnPos3;
    private GameObject[] spawnPositions;
    private bool[] spawnPositionsBusy;
    private float hardEnemyChance;

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
        spawnPositionsBusy = new bool[] { false, false, false};
        spawnPositions = new GameObject[] { spawnPos1, spawnPos2, spawnPos3 };
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemy();
    }

    private GameObject getSpawnPoint(int randomSpawnPointNumber) {
        switch (randomSpawnPointNumber) {
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

    private void spawnEnemy() {
         float randomHardEnemyChanceNumber = Random.Range(0F, 100F);
         int randomSpawnPointNumber = Random.Range(0, 3);
            if (randomHardEnemyChanceNumber <= hardEnemyChance) {
                if (!spawnPositionsBusy[randomSpawnPointNumber]) {
                    GameManager.Instance.spawnedEntities[randomSpawnPointNumber] = Instantiate(hardEnemy, getSpawnPoint(randomSpawnPointNumber).transform.position, Quaternion.identity);
                    spawnPositionsBusy[randomSpawnPointNumber] = true;
                }
            } else {
                if (!spawnPositionsBusy[randomSpawnPointNumber]) {
                    GameManager.Instance.spawnedEntities[randomSpawnPointNumber] = Instantiate(lightEnemy, getSpawnPoint(randomSpawnPointNumber).transform.position, Quaternion.identity);
                    spawnPositionsBusy[randomSpawnPointNumber] = true;
                }
            }
    }
}
