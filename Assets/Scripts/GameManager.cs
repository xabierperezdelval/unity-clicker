using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int difficultyLevel;
    private string[] enemyType;

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = 1;
        enemyType = new string[] { "lightEnemy", "hardEnemy" };
        EnemyDataTemplate.Instance.getDifficulty(difficultyLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
