using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public Transform Target;
    [SerializeField]private float speed;

    public GameObject PlayerMove;
    public GameObject PlayerCombat;
    public CinemachineFreeLook freeLookCamera;

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
        Debug.Log("Change");
        PlayerMove.SetActive(Activate);
        Activate = !Activate; // true
        PlayerCombat.SetActive(Activate);
        
        if (Activate)
        {
            Target = PlayerCombat.transform;
        }
        else
        {
            Target = PlayerMove.transform;
        }
        
        // Change the CinemachineFreeLook targets
        if (freeLookCamera)
        {
            freeLookCamera.Follow = Target;
            freeLookCamera.LookAt = Target;
        }
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "EnemySpawn")
    //     {
    //         ChangePLayers();
    //     }
    // }
}