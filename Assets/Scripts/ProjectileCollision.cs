using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public event Action<Transform> OnDeath = delegate {  };

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == null) return;
        if (!other.attachedRigidbody.GetComponent<AmmunitionScript>()) return;
        OnDeath?.Invoke(transform);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
