using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;

public class AR_TapToPlaceObject : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject objectToPlace;
    private ARSessionOrigin arOrigin;
    private ARRaycastManager aRRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool isObjectInScene = false;
    public EyeColourSwapping eyeColourSwapping;
    public ShoeColourSwapping shoeColourSwapping;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    
    void Update()
    {

        if (isObjectInScene == false)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
        else
        {
             
        }

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isObjectInScene == false)
        {

            PlaceObject();
            isObjectInScene = true;
            eyeColourSwapping.enabled = true;
            shoeColourSwapping.enabled = true;

        }

        
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
    }

    //Update placment Indicator to show if In can drop an object
    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {

            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    //Check if i can place an object
    private void UpdatePlacementPose() 
    {
        var screenCentre = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCentre, hits, TrackableType.Planes);
        
        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBaring = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

       

            placementPose.rotation = Quaternion.LookRotation(cameraBaring);
        }

    }
}
