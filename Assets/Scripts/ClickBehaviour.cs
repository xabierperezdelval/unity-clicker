using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBehaviour : MonoBehaviour
{
    public AudioSource playerAttackSound;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        playerAttackSound.Play();
        if (GameManager.Instance.berserkerRageActive)
        {
            damage = 2;
        } else
        {
            damage = 1;
        }
        gameObject.GetComponent<EnemyDataTemplate>().enemyHealth -= damage;
    }
}
