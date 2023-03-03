using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadBehaviour : MonoBehaviour

    
{
    private float enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = EnemyDataTemplate.Instance.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {

        }
    }
}
