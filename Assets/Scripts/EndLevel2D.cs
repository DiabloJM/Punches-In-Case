using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel2D : MonoBehaviour
{
    public GameObject endAnimation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement2d playerRef = collision.GetComponent<PlayerMovement2d>();
            playerRef.rb.velocity = new Vector2(5, 0);
            playerRef.rb.gravityScale = 0;
            endAnimation.SetActive(true);
            Invoke("ChangeLevel", 1.3f);
        }
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene("TheDocksTest");
    }
}
