using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string levelName = "MainMenu";
    //Funcion para ir al menu 
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //Funcion para ir al nivel 1
    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TheCity");
    }

    //Funcion para ir al nivel 2
    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TheBridge");
    }

    //Funcion para ir al nivel 3
    public void Level3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TheDocksTest");
    }

    //Funcion para pausar el juego
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    //Funcion para reanudar el juego
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    //Funcion para salir del juego
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
    }

    //Funcion para regresar al jugador al menu tras completar un nivel
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeLevel();
        }
    }
}
