using UnityEngine;

public class BallStuckToGround : MonoBehaviour
{
    public float groundDistance = 0.5f;
    public LayerMask groundLayer;       

    private Rigidbody rb;
    private Vector3 groundNormal;

    void Start()
    {

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, groundLayer))
        {
            groundNormal = hit.normal;
            Vector3 targetPosition = hit.point + groundNormal * groundDistance;
            rb.MovePosition(targetPosition);
        }
        else
        {
            Debug.LogWarning("Ground not detected below the ball.");
        }
    }
}

