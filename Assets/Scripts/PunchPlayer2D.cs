using UnityEngine;

public class PunchPlayer2D : MonoBehaviour
{
    PlayerMovement2d playerRef;

    private void Start()
    {
        playerRef = transform.parent.GetComponent<PlayerMovement2d>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy2D Enemy = collision.gameObject.GetComponent<Enemy2D>();
            Enemy.MakeDamage(playerRef.damage);
        }
    }
}
