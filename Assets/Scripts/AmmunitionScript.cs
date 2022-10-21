using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
