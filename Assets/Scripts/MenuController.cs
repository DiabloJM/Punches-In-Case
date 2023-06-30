using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Funcion para ir al nivel 1
    public void Level1()
    {
        SceneManager.LoadScene("TheCity");
    }

    //Funcion para ir al nivel 2
    public void Level2()
    {
        SceneManager.LoadScene("TheBridge");
    }

    //Funcion para ir al nivel 3
    public void Level3()
    {
        SceneManager.LoadScene("TheDocks");
    }
}
