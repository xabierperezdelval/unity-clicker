using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    private float enemyAttackSpeed, enemyDamage;
    [SerializeField] private float attackTimer;
    private bool attackAllowed;
    public AudioSource enemyAttackSound;
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
            enemyAttackSound.Play();
            if (!GameManager.Instance.invencibleTimerActive && GameManager.Instance.morale < 80)
            {
                GameManager.Instance.morale -= enemyDamage;
            }
            attackAllowed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0 && GameManager.Instance.isGameLoopRunning)
        {
            AttackAction();
            SetAttackTimer();
        }
    }
}
