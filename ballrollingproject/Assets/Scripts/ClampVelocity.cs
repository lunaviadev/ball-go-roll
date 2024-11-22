using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ClampVelocity : MonoBehaviour
{
    [Range(-1000000f, 0f)] public float downwardForce = -500000f;
    private Rigidbody _rb;

    private void Start() => _rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        _rb.AddForce(0f, downwardForce, 0f);
    }

}
