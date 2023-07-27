using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerChange : MonoBehaviour
{
    [FormerlySerializedAs("Target")] public Transform target;
    [SerializeField]private float speed;


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }


}