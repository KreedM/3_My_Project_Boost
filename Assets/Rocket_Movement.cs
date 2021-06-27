using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;
    
    [SerializeField] float rcsThrust = 2f;
    [SerializeField] float mainThrust = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // FixedUpdate() depends on FixedTimeStep (default 0.2s 50fps), put physics/rigidbody manipulations in here.
    void FixedUpdate()
    {
        checkThrust();
        checkRotate();
    }

    void checkThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(mainThrust * Vector3.up);
            if (!audioSource.isPlaying) //Prevents layering - new clips playing every single frame
                audioSource.Play();
        }
        else
            audioSource.Stop();
    }
    
    void checkRotate()
    {
        rigidBody.freezeRotation = true; //Pause physics rotation in case rocket hits obstacle (won't madly rotate

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rcsThrust * Vector3.back); //Forward means Z axis
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rcsThrust * Vector3.forward); //Forward means Z axis
        }

        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly": print("OK."); break;
            default: print("Dead."); break;
        }
    }
}
