using UnityEngine;

public class ExperienceAndLevel : MonoBehaviour, IExperience, ILevel
{
    [SerializeField] public int m_Experience = 0;
    [SerializeField] private int m_Level = 0;
    [SerializeField] public int m_ExperiencePerLevel;
    [SerializeField] private int m_MultiplierPerLevel;

    public int Experience => m_Experience;
    public int Level => m_Level;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddExperience(50);
        }
    }

    public void AddExperience(int experience)
    {
        experience = Mathf.Abs(experience);

        int experienceToUpgrade = m_ExperiencePerLevel * m_MultiplierPerLevel;

        int remainingExperience = experience;
        while (remainingExperience >= experienceToUpgrade)
        {
            AddLevel(1);
            remainingExperience -= experienceToUpgrade;
            experienceToUpgrade = m_ExperiencePerLevel * m_MultiplierPerLevel;
        }

        m_Experience += remainingExperience;
    }

    public void AddLevel(int level)
    {
        level = Mathf.Abs(level);
        m_Level += level;
        m_ExperiencePerLevel *= m_MultiplierPerLevel;
    }
}