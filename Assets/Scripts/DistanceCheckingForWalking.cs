using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Handles the distance checks between the Instantiated model and the AR Camera (Or any other game object), 
/// Sets the Model to look at the object it is in a distance check with
/// </summary>
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

        Test = GameObject.Find("Debug");
        debugText = Test.GetComponentInChildren<TMP_Text>();

    }

    void Update()
    {
        LookAtCamera();

        currentDistance = Vector3.Distance(distanceCube.transform.position, transform.position);
        currentDistanceRounded = Mathf.Round(currentDistance * 100) / 100;
        debugText.text = "Current Distance: " + currentDistanceRounded;

        if (currentDistance > distanceToCheck)
        {
            //turn on walking, moving using root motion
            animController.SetBool("farAway", true);
        }
        else
        {
            animController.SetBool("farAway", false);
        }

        //if (currentDistance > 5)
        //{
          //  animController.SetBool("farAway", false);
            //Just debug trigger so the model will not walk too far away if not heading towards camera
        //}

    }

    /// <summary>
    /// Sets the object to look at another object, but keeps the rotation straight with the feet on the floor
    /// </summary>
    public void LookAtCamera()
    {
        var lookPos = distanceCube.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

    }

}
