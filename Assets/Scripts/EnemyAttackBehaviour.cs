using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    private float enemyAttackSpeed, enemyDamage;
    [SerializeField] private float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        enemyAttackSpeed = gameObject.GetComponent<EnemyDataTemplate>().enemyAttackSpeed;
        enemyDamage = gameObject.GetComponent<EnemyDataTemplate>().enemyDamage;
        setAttackTimer();
    }

    private void setAttackTimer() {
        attackTimer = Random.Range(9F, 11F) * enemyAttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0) {
            GameManager.Instance.morale =- enemyDamage;
            setAttackTimer();
        }
    }
}
