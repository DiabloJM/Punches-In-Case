using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public Transform Target;
    [SerializeField]private float speed;

    public GameObject PlayerMove;
    public GameObject PlayerCombat;
    private bool Activate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }

    public void ChangePLayers()
    {
        PlayerMove.SetActive(Activate);
        Activate = !Activate;
        PlayerCombat.SetActive(Activate);
        Activate = !Activate;
        if (Activate)
        {
            Target = PlayerMove.transform;
        }
        else
        {
            Target = PlayerCombat.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemySpawn")
        {
            ChangePLayers();
        }
    }
}
