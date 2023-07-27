using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2d : MonoBehaviour
{
    public Animator animator; // Variable para almacenar la referencia al componente Animator
    public float movementSpeed = 5f;
    public int vidaPlayer = 50;

    string CrescentKick2dParameter = "CrescentKick2d";
    string EnemyHit2dParameter = "EnemyHit";
    string Run2d = "Run";
    string FlyingPunchCombo2d = "FlyingPunchCombo2d";

    private Vector3 movementDirection;
    private bool isRunning;

    private void Start()
    {
        SetPlayerScale(1f);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
       

        // Mover al jugador en la dirección calculada
        movementDirection = new Vector3(horizontalInput, 0f).normalized;
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Reproducir la animación al hacer clic izquierdo
        if (Input.GetMouseButton(0))
        {
            animator.SetBool(CrescentKick2dParameter, true);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool(FlyingPunchCombo2d, true);
        }

        // Controlar la animación de correr
        isRunning = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool(Run2d, isRunning);

     


        // Cambiar la escala según la dirección
        if (horizontalInput < 0f)
        {
            SetPlayerScale(-1f);
            animator.SetBool(CrescentKick2dParameter, false);
            animator.SetBool(FlyingPunchCombo2d, false);
        }
        else if (horizontalInput > 0f)
        {
            SetPlayerScale(1f);
            animator.SetBool(CrescentKick2dParameter, false);
            animator.SetBool(FlyingPunchCombo2d, false);
        }
    }

    // Función para cambiar el local scale del jugador
    private void SetPlayerScale(float scaleX)
    {
        transform.localScale = new Vector3(scaleX, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Auchhh");
            animator.SetBool(EnemyHit2dParameter, true);
            vidaPlayer -= 25;
        }
    }
}
