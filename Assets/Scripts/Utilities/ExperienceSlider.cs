using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject FillArea;
    public ExperienceAndLevel player;
    public Text text;
    public EnemyScript enemy;
    public int enemyHealth = 5;
    int levelNumber = 1;

    private void Start()
    {
        slider.maxValue = player.m_ExperiencePerLevel;
        text.text = levelNumber.ToString();
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
            if (slider.value == 200)
            {
                player.m_Experience = 0;
                levelNumber++;
                text.text = levelNumber.ToString();
                if(enemyHealth - 1 > 1)
                {
                    enemyHealth--;
                }
            }
        }
    }
}
