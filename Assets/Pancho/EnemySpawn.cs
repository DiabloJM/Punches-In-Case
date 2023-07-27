using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Spawn;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Spawn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}