using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
        SceneManager.LoadScene("TheDocks");
    }

    //Funcion para salir del juego
    public void Exit()
    {
        Application.Quit();
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

    //Funcion para regresar al menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
