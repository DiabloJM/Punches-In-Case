using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public int health;

    public void Heal(float value)
    {
        value = Mathf.Abs(value);
        health = (int)Mathf.Clamp(health + value, 0, 100);
        
    }
    
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Damage(float value)
    {
        value = Mathf.Abs(value);
        health = (int)Mathf.Clamp(health - value, 0, 100);
        if (value == 0)
            Menu();
    }
}
