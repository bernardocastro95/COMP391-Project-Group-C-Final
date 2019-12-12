using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BackgroundMoves : MonoBehaviour
    {

        public float movementSpeed = 10;

        private Rigidbody rb;
        public Vector3 endPosition = new Vector3(-8, 100, 1000);
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rb.position != endPosition)
            {
                Vector3 newPosition = Vector3.MoveTowards(rb.position, endPosition, movementSpeed * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
        }
    }


