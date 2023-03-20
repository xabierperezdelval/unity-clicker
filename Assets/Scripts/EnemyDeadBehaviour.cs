using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadBehaviour : MonoBehaviour


{
    private float enemyHealth;
    public AudioSource enemyDeadSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth = gameObject.GetComponent<EnemyDataTemplate>().enemyHealth;
        if (gameObject != null && enemyHealth <= 0)
        {
            enemyDeadSound.Play();
            Destroy(gameObject);
            GameManager.Instance.enemiesLeft -= 1;
            EnemySpawner.Instance.spawnPositionsBusy[gameObject.GetComponent<EnemyDataTemplate>().spawnedPos] = false;
        }
    }
}
