using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2d : MonoBehaviour
{
    public Animator animator; // Variable para almacenar la referencia al componente Animator
    public float movementSpeed = 5f;
    private int health = 100;

    string CrescentKick2dParameter = "CrescentKick2d";
    string EnemyHit2dParameter = "EnemyHit";
    string Run2d = "Run";
    string FlyingPunchCombo2d = "FlyingPunchCombo2d";

    private Vector3 movementDirection;
    private bool isRunning;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
       

        // Mover al jugador en la dirección calculada
        movementDirection = new Vector3(horizontalInput, 0f).normalized;
       

        if (horizontalInput != 0)
        {
            if(horizontalInput < 0)
            {
                rb.velocity = new Vector2(Mathf.Clamp((rb.velocity.x - movementSpeed * Time.deltaTime), -5, 0), 0);
            }
            else
            {
                rb.velocity = new Vector2(Mathf.Clamp((rb.velocity.x + movementSpeed * Time.deltaTime), 0, 5), 0);
            }
            transform.localScale = new Vector2(horizontalInput, 1);
        }


        // Reproducir la animación al hacer clic izquierdo
        if (Input.GetMouseButton(0))
        {
            animator.SetBool(CrescentKick2dParameter, true);
            Invoke("DeactivateAnimationKick", 1);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool(FlyingPunchCombo2d, true);
            Invoke("DeactivateAnimationPunch", 1);
        }

        // Controlar la animación de correr
        isRunning = Mathf.Abs(rb.velocity.x) != 0;
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

    public void MakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject, 3.0f);
        }
        else
        {
            animator.SetBool("EnemyHit", true);
            Invoke("DeactivateAnimation", 1);
        }
    }


    void DeactivateAnimation()
    {
        animator.SetBool("EnemyHit", false);
    }
    void DeactivateAnimationKick()
    {
        animator.SetBool(CrescentKick2dParameter, false);
    }
    void DeactivateAnimationPunch()
    {
        animator.SetBool(FlyingPunchCombo2d, false);
    }
}

