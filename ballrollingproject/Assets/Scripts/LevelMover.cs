using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class LevelMover : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField]private Vector3 currentValue;

    private Transform playerTransform;

    private float moveHorizontal;
    private float moveVertical;

    private void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
       playerTransform = gameObject.transform;
    }
    void Update()
    {   

        
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 moveForward = new Vector3(moveVertical * Time.deltaTime, 0, moveHorizontal * Time.deltaTime);

        //currentValue = moveForward;
        //transform.Rotate(moveForward);

        
        // Move the Rigidbody (Apply translation)
        rb.MovePosition(rb.position + moveForward);

        // Handle rotation: rotate around the Y-axis
        //float rotationInput = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;

        CheckValue();  
        Quaternion deltaRotation = Quaternion.Euler(moveVertical, 0f , moveHorizontal);  // Rotation around the Y-axis
        rb.MoveRotation(rb.rotation * deltaRotation);
 
    }

    private void CheckValue()
    {
        if ((playerTransform.eulerAngles.x < 325 && playerTransform.eulerAngles.x > 40) && moveVertical < 0)
        {
            moveVertical = 0;
        }
        if ((playerTransform.eulerAngles.x > 35f && playerTransform.eulerAngles.x < 39f) && moveVertical > 0)
        {
            moveVertical = 0;
        }

        if((playerTransform.eulerAngles.z < 325 && playerTransform.eulerAngles.z > 40) && moveHorizontal < 0)
        {
            moveHorizontal = 0;
        }
        else if((playerTransform.eulerAngles.z > 35f && playerTransform.eulerAngles.z < 39f) && moveHorizontal > 0)
        {
            moveHorizontal = 0;
        }
    }


}
