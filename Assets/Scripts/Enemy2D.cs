using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    int health;
    [SerializeField]
    int damage;

    bool goToPlayer;
    bool attack;

    GameObject playerRef;

    [SerializeField]
    float speed;

    [SerializeField]
    Animator anim;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        UpdateStates();
        if(goToPlayer)
        {
            float direction = playerRef.transform.position.x - transform.position.x;
            if (direction < 0)
            {
                rb.velocity = new Vector2(Mathf.Clamp((rb.velocity.x - speed * Time.deltaTime), -5, 0), 0);
                transform.localScale = new Vector2(1, 1);
            }
            else
            {          
                rb.velocity = new Vector2(Mathf.Clamp((rb.velocity.x + speed * Time.deltaTime), 0, 5),0);
                transform.localScale = new Vector2(-1, 1);
            }
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("Speed", 0);
        }

        anim.SetBool("Attack", attack);
    }

    float CalculateDistancePlayer()
    {
        float distance = Mathf.Abs(playerRef.transform.position.x - transform.position.x);
        return distance;
    }

    void UpdateStates()
    {
        float getDistance = CalculateDistancePlayer();
        if (getDistance <= 6 && getDistance >= 2)
        {
            goToPlayer = true;
            attack = false;
        }
        else if(getDistance > 6)
        {
            goToPlayer = false;
        }
    }

    public void MakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            anim.SetBool("Death", true);
            Destroy(gameObject, 3.0f);
        }
        else
        {
            anim.SetBool("Hit", true);
            Invoke("DeactivateAnimation", 1);
        }
    }

    void DeactivateAnimation()
    {
        anim.SetBool("Hit", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attack = true;
            goToPlayer = false;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attack = false;
            goToPlayer = true;
        }
    }
}