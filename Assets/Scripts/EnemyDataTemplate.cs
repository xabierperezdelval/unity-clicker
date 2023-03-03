using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDataTemplate : MonoBehaviour
{
    [SerializeField] public float enemyHealth;
    [SerializeField] public float enemyAttackSpeed;
    [SerializeField] private float enemyDamage;
    [SerializeField] private string enemyType;

    //creamos una instancia para manejar los parámetros desde otros objetos
    public static EnemyDataTemplate Instance { get; private set; }

    //prevenimos múltiples copias/instancias
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

    }

    public void getDifficulty(int difficultyLevel)
    {
        //enemyType = enemyTypeTagArray[Random.Range(0, enemyType.Length)];
        if (gameObject.tag == "LightEnemy") {
            enemyHealth = 40 * difficultyLevel * Random.Range(0.8F, 0.95F);
            enemyAttackSpeed = 1 * difficultyLevel * Random.Range(0.8F, 0.9F);
            enemyDamage = 8 * difficultyLevel * Random.Range(0.12F, 0.42F);
        }
        if (gameObject.tag == "HardEnemy")
        {
            enemyHealth = 75 * difficultyLevel * Random.Range(0.8F, 0.95F);
            enemyAttackSpeed = 0.5F * difficultyLevel * Random.Range(0.6F, 0.8F);
            enemyDamage = 20 * difficultyLevel * Random.Range(0.17F, 0.40F);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
