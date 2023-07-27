using UnityEngine;

public class PunchCollider2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            /*Reemplazar por funcion y clase del jugador final*/
            print("Le pegue");
        }
    }
}
