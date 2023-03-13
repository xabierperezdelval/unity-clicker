using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
    
{

    private int spawnPosNumber;
    private float maxHealth, currentHealth;
    Image bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        spawnPosNumber = EnemySpawner.Instance.spawnPositionNumber;
        maxHealth = GameManager.Instance.spawnedEntities[spawnPosNumber].GetComponent<EnemyDataTemplate>().enemyHealth;
}

    // Update is called once per frame
    void Update()
    {
        currentHealth = GameManager.Instance.spawnedEntities[spawnPosNumber].GetComponent<EnemyDataTemplate>().enemyHealth;
        bar.fillAmount = currentHealth / maxHealth;
        if (bar.fillAmount == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
