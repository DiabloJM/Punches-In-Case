using UnityEngine;

public class PunchEnemy2D : MonoBehaviour
{
    HealthSlider2D health;

    private void Start()
    {
        health = GameObject.FindObjectOfType<HealthSlider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement2d Player = collision.gameObject.GetComponent<PlayerMovement2d>();
            Player.MakeDamage(25);
            health.UpdateHealthSlider();
        }
    }
}
