using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDataTemplate : MonoBehaviour
{
    [SerializeField] public float enemyHealth;
    [SerializeField] public float enemyAttackSpeed;
    [SerializeField] public float enemyDamage;

    public int difficultyLevel;

    //creamos una instancia para manejar los par�metros desde otros objetos
    public static EnemyDataTemplate Instance { get; private set; }

    //prevenimos m�ltiples copias/instancias
    // void Awake()
    // {
    //     if (Instance != null)
    //         Destroy(Instance);
    //     Instance = this;
    // }

    // void OnDestroy()
    // {
    //     if (Instance == this)
    //     {
    //         Instance = null;
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = GameManager.Instance.difficultyLevel;
        setStats();
    }

    public void setStats()
    {
        //enemyType = enemyTypeTagArray[Random.Range(0, enemyType.Length)];
        if (gameObject.tag == "LightEnemy") {
            enemyHealth = 20 * difficultyLevel * Random.Range(0.8F, 0.95F);
            enemyAttackSpeed = 1 * difficultyLevel * Random.Range(0.8F, 0.9F);
            enemyDamage = 8 * difficultyLevel * Random.Range(0.12F, 0.42F);
        }
        if (gameObject.tag == "HardEnemy")
        {
            enemyHealth = 50 * difficultyLevel * Random.Range(0.8F, 0.95F);
            enemyAttackSpeed = 0.5F * difficultyLevel * Random.Range(0.6F, 0.8F);
            enemyDamage = 20 * difficultyLevel * Random.Range(0.17F, 0.40F);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
