using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;

public class DistanceCheckingForWalking : MonoBehaviour
{
    public float distanceToCheck = 1.5f;
    public float currentDistance = 0.0f;
    public float currentDistanceRounded = 0.0f;
    public GameObject distanceCube;
    public Animator animController; // Camera Window
    public TMP_Text debugText;
    public GameObject Test;


    private void Start()
    {
        distanceCube = GameObject.FindGameObjectWithTag("MainCamera");
        //Test = GameObject.Find("Debug");
        
            
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(distanceCube.transform.position, transform.position);
        currentDistanceRounded = Mathf.Round(currentDistance * 100) / 100;
        //debugText.text = "Current Distance: " + currentDistanceRounded;

        if (currentDistance > distanceToCheck)
        {
            //turn on walking, move towards block
            animController.SetBool("farAway", true);

        }
        else
        {
            animController.SetBool("farAway", false);
        }


        if (currentDistance > 5)
        {

            animController.SetBool("farAway", false);
        }

    }
}
