using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [FormerlySerializedAs("enemiesCounter")] [HideInInspector] public int enemiesDefeatedCounter = 0;
    [SerializeField] private string levelToLoad;
    [FormerlySerializedAs("CombatScript")] public CombatScript combatScript;

    private int maxEnemyCount = 1000;

    //Variables para el menu de pausa
    public GameObject pauseMenu;
    [SerializeField] private GameObject pause;

    public void SetMaxAvailableEnemyCount()
    {
        maxEnemyCount = combatScript.enemyManager.AvailableEnemyCount();
        Debug.Log($"maxEnemyCount: {maxEnemyCount}");
    }

    void Update()
    {
        Debug.Log($"enemiesCounter: {enemiesDefeatedCounter}");
        if (maxEnemyCount <= enemiesDefeatedCounter )
        {
            Debug.Log("Change Enemy Manager");
            combatScript.ChangeEnemyManagerCounter();
            enemiesDefeatedCounter = 0;
        }

        //If para comprobar si el jugador presiona el boton de pausa
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause.GetComponent<MenuController>().Pause();

            pauseMenu.SetActive(true);
        }
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}