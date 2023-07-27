using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public Transform Target;
    [SerializeField]private float speed;


    private bool Activate = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
    }


}