using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider2D : MonoBehaviour
{
    public PlayerMovement2d player;
    public Slider slider;
    public void UpdateHealthSlider()
    {
        slider.value = player.health;
    }
}
