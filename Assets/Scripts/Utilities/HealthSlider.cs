using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject FillArea;
    public PlayerHealth player;
    void Update()
    {
        if (player.health == 0)
            FillArea.SetActive(false);
        else
        {
            FillArea.SetActive(true);
            slider.value = player.health;
        }
    }
}
