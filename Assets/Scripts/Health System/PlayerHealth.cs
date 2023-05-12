using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour, IHealth
{
    public float health;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Heal(10.0f);
        if (Input.GetKeyDown(KeyCode.F))
            Damage(10.0f);
    }

    public void Heal(float value)
    {
        value = Mathf.Abs(value);
        health = Mathf.Clamp(health + value, 0, 100);
    }

    public void Damage(float value)
    {
        value = Mathf.Abs(value);
        health = Mathf.Clamp(health - value, 0, 100);
    }
}
