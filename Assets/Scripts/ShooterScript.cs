using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float slowDown = 0.1f;

    private float nextShot;
    
    private void Update()
    {
        if(nextShot > Time.time) return;
        if (!Input.GetKey(KeyCode.Space)) return;
        nextShot = Time.time + slowDown;
        Instantiate(projectilePrefab, transform.position + transform.forward * 0.3f, Quaternion.identity);
    }
}
