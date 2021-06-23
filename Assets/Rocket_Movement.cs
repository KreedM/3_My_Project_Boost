using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Movement : MonoBehaviour
{
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(50 * Vector3.back * Time.deltaTime); //Forward means Z axis
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(50 * Vector3.forward * Time.deltaTime); //Forward means Z axis
        }
    }
}
