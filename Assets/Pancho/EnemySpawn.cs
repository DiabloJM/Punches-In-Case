using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    [FormerlySerializedAs("Spawn")] public GameObject spawn;

    public MusicController musicController;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawn.SetActive(true);
            musicController.ChangeMusicState();
            gameObject.SetActive(false);
        }
    }
}