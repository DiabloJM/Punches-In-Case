using UnityEngine;

//Clase que implementan las interfaces para tener manejo de la experiencia y nivel 
public class ExperienceAndLevel : MonoBehaviour, IExperience, ILevel
{
    [SerializeField] public int m_Experience = 0; //Cantidad de experiencia
    [SerializeField] private int m_Level = 0; //Nivel actual del jugador
    [SerializeField] public int m_ExperiencePerLevel; //Experiencia que necesita el jugador para subir de nivel
    [SerializeField] private int m_MultiplierPerLevel; //Multiplicador por nivel

    public int Experience => m_Experience;
    public int Level => m_Level;

    private void Update()
    {
        //Metodo para probar el sistema
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Experience += 50;

            AddExperience(m_Experience);
        }
    }

    public void AddExperience(int experience)
    {
        //Asegurarse de que sea un valor positivo
        experience = Mathf.Abs(experience);

        //Almacenar la experiencia temporalmente para realizar operaciones sobre ella
        int remainingExperience = experience;

        /*do
        {
            //Calcula la cantidad maxima de experiencia necesaria para cambiar de nivel
            int experienceToUpgrade = m_ExperiencePerLevel * m_MultiplierPerLevel;

            //Si la cantidad de experiencia a agregar hace que suba de nivel
            if (m_Experience + remainingExperience >= experienceToUpgrade)
            {
                //Añade un nivel de experiencia
                AddLevel(1);

                //Calcular la cantidad de experiencia agregada y la resta de la experiencia temporal
                int added = experienceToUpgrade - m_Experience;
                remainingExperience -= added;
            }
            else
            {
                //Asignar la experiencia sobrante y terminar el while
                m_Experience = remainingExperience;
                remainingExperience = 0;
            }
        } while (remainingExperience > 0);*/
    }

    //Funcion para sumar un nivel al jugador
    public void AddLevel(int level)
    {
        //Evitar que sea negativo y agregar experiencia
        level = Mathf.Abs(level);
        m_Level += level;

        //Formula para calcular el incremento de experiencia necesaria para subir de nivel
        m_ExperiencePerLevel = m_ExperiencePerLevel * m_MultiplierPerLevel;
    }
} 