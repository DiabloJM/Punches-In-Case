using UnityEngine;

public class PunchEnemy2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement2d Player = collision.gameObject.GetComponent<PlayerMovement2d>();
            Player.MakeDamage(25);
            print("Le pegue");
        }
    }
}
