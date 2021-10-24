using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 myMovement;
    private Quaternion myRotation = Quaternion.identity;
    public float turnSpeed = 20f;
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private AudioSource myAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        myMovement.Set(horizontal,0,vertical);
        myMovement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = (hasHorizontalInput || hasVerticalInput);
        myAnimator.SetBool("isWalking", isWalking);

        if(isWalking)
        {
            if(!myAudioSource.isPlaying)
            {
                myAudioSource.Play();
            }
        }
        else
        {
            myAudioSource.Stop();
        }

        Vector3 desiredFoward = Vector3.RotateTowards(transform.forward, myMovement, turnSpeed * Time.deltaTime, 0f);
        myRotation = Quaternion.LookRotation(desiredFoward);
    }

    private void OnAnimatorMove()
    {
        myRigidbody.MovePosition(myRigidbody.position + myMovement *myAnimator.deltaPosition.magnitude);
        myRigidbody.MoveRotation(myRotation);
    }
}
