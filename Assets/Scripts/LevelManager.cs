using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public int enemiesCounter = 0;
    [SerializeField] private string levelToLoad;
    [FormerlySerializedAs("CombatScript")] public CombatScript combatScript;

    private int maxEnemyCount;
    // Update is called once per frame


    public void SetMaxAvailableEnemyCount()
    {
        maxEnemyCount = combatScript.enemyManager.AvailableEnemyCount();
        Debug.Log($"maxEnemyCount: {maxEnemyCount}");
    }

    void Update()
    {
        if (enemiesCounter > maxEnemyCount)
        {
            Debug.Log("Change Enemy Manager");
            combatScript.ChangeEnemyManagerCounter();
            enemiesCounter = 0;
        }
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}