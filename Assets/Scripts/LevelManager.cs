using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public int enemiesCounter = 0;
    [SerializeField] private string levelToLoad;
    public CombatScript CombatScript;
    // Update is called once per frame
    void Update()
    {
        if (enemiesCounter > CombatScript.enemyManager.AvailableEnemyCount())
        {
            Debug.Log("Change Enemy Manager");
            CombatScript.ChangeEnemyManagerCounter();
            enemiesCounter = 0;
        }
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}