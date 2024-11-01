using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    
        public float moveSpeed = 2f; 
        public float moveDistance = 5f; 
        private Vector3 startingPosition;
        private Vector3 targetPosition;
        private bool movingRight = true;

        void Start()
        {
            startingPosition = transform.position; 
            targetPosition = startingPosition + new Vector3(moveDistance, 0, 0); 
        }

        void Update()
        {
            if (movingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    movingRight = false; // Switch direction
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
                {
                    movingRight = true; 
                }
            }
        }
    
}
