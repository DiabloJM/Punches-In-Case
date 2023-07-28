using UnityEngine;

public class PunchPlayer2D : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy2D Enemy = collision.gameObject.GetComponent<Enemy2D>();
            Enemy.MakeDamage(25);
        }
    }
}
