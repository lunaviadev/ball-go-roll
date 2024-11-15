using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 Velocity;
    [SerializeField] private Rigidbody BallRigid;


    private void Start()
    {
        BallRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Velocity = BallRigid.velocity;

        Vector3 velocityClamp = new Vector3(ClampVector(Velocity.x), ClampVector(Velocity.y), ClampVector(Velocity.z));

        BallRigid.velocity = velocityClamp;
    }

    private float ClampVector(float vectorValue)
    {
        return Mathf.Clamp(vectorValue, -10, 10);
    }
}
