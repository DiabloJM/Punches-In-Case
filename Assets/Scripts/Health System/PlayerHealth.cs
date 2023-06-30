using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour, IHealth
{
    public int health;

    public void Heal(float value)
    {
        value = Mathf.Abs(value);
        health = (int)Mathf.Clamp(health + value, 0, 100);
    }

    public void Damage(float value)
    {
        value = Mathf.Abs(value);
        health = (int)Mathf.Clamp(health - value, 0, 100);
    }
}
