using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    private float enemyAttackSpeed, enemyDamage;
    [SerializeField] private float attackTimer;
    private bool attackAllowed;
    // Start is called before the first frame update
    void Start()
    {
        attackAllowed = true;
        enemyAttackSpeed = gameObject.GetComponent<EnemyDataTemplate>().enemyAttackSpeed;
        enemyDamage = gameObject.GetComponent<EnemyDataTemplate>().enemyDamage;
        SetAttackTimer();
    }

    private void SetAttackTimer()
    {
        attackTimer = Random.Range(9F, 11F) * enemyAttackSpeed;
        attackAllowed = true;
    }

    private void AttackAction()
    {
        if (attackAllowed)
        {
            GameManager.Instance.morale -= enemyDamage;
            attackAllowed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            AttackAction();
            SetAttackTimer();
        }
    }
}
