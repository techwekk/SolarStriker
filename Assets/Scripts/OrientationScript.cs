using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xAxisBounds = 3f;
    
    void Update()
    {
        transform.position =
            new Vector3( Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, -xAxisBounds, xAxisBounds) , 0, 0);
    }
}
