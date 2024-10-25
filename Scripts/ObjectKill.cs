using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKill : MonoBehaviour
{
    public Vector3 startingPosition;
    public string collisionObjectTag = "ResetTrigger";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = startingPosition;
        }
    }
}
