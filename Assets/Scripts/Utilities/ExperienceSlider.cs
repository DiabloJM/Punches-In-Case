using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject FillArea;
    public ExperienceAndLevel player;

    private void Start()
    {
        slider.maxValue = player.m_ExperiencePerLevel;
    }
    void Update()
    {
        if (player.m_Experience == 0)
        {
            FillArea.SetActive(false);
        }

        else
        {
            FillArea.SetActive(true);
            slider.maxValue = player.m_ExperiencePerLevel;
            slider.value = player.m_Experience;
        }
    }
}
