using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    [HideInInspector] public int enemiesCounter = 0;
    [SerializeField] private string levelToLoad;
    public PlayerChange playerChange;


    // Update is called once per frame
    void Update()
    {
        if (enemiesCounter >= 5)
        { 
            Invoke("_ChangePlayer", 4.0f);
            enemiesCounter = 0;
        }
    }

    private void _ChangePlayer()
    {
           playerChange.ChangePLayers();
        
    }
    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
