using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    [HideInInspector] public int enemiesCounter = 0;
    [SerializeField] private string levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (enemiesCounter >= 5)
        {
           Invoke("ChangeLevel", 5.0f); 
        }
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
