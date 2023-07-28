using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2d : MonoBehaviour
{
    public Animator animator; // Variable para almacenar la referencia al componente Animator
    public float movementSpeed = 5f;
    public int health = 100;
    public int damage;

    string CrescentKick2dParameter = "CrescentKick2d";
    string Run2d = "Run";
    string FlyingPunchCombo2d = "FlyingPunchCombo2d";

    private bool isRunning;
    public Rigidbody2D rb;

    bool canWalk = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0 || Time.timeScale == 0)
            return;
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0 && canWalk)
        {
            if(horizontalInput < 0)
            {
                rb.velocity = new Vector2(Mathf.Clamp((rb.velocity.x - movementSpeed * Time.deltaTime), -5, 0), 0);
            }
            else
            {
                rb.velocity = new Vector2(Mathf.Clamp((rb.velocity.x + movementSpeed * Time.deltaTime), 0, 5), 0);
            }
            transform.localScale = new Vector3(horizontalInput, 1, 1);
        }


        // Reproducir la animación al hacer clic izquierdo
        if (Input.GetMouseButton(0))
        {
            animator.SetBool(CrescentKick2dParameter, true);
            Invoke("DeactivateAnimationKick", 1);
            damage = 15;
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetBool(FlyingPunchCombo2d, true);
            canWalk = false;
            damage = 25;
            Invoke("TimerStay", 1.12f);
            Invoke("SetWalk", 2);
            Invoke("DeactivateAnimationPunch", 1);
        }

        // Controlar la animación de correr
        isRunning = Mathf.Abs(rb.velocity.x) != 0;
        animator.SetBool(Run2d, isRunning);
    }

    public void MakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            Invoke("ResetLevel", 3.0f);
        }
        else
        {
            animator.SetBool("EnemyHit", true);
            Invoke("DeactivateAnimation", 1);
        }
    }

    void TimerStay()
    {
        rb.velocity = Vector3.zero;
    }
    void SetWalk()
    {
        canWalk = true;
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

    void ResetLevel()
    {
        SceneManager.LoadScene("TheBridge");
    }
}

