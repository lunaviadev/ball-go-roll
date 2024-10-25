using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class LevelMover : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField]private Vector3 currentValue;
    private void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {   

        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;


        Vector3 moveForward = new Vector3(moveVertical * Time.deltaTime, 0, moveHorizontal * Time.deltaTime);
        currentValue = moveForward;
        transform.Rotate(moveForward);

        /*if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Thing work");
            Vector3 moveForward = new Vector3(0, 0, 100);
            rb.AddTorque(moveForward);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Other thing work");
            Vector3 moveBack = new Vector3(100, 0, 0);
            rb.AddTorque(moveBack);
            return;
        }*/


    }
}
