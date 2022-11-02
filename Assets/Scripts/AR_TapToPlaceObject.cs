using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Handles the placement indicator code to appear on Horizontal planes and then Instantiate a model on a tap of a screen
/// </summary>
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

    /// <summary>
    /// Update the sprite to appear if valid, if not set to not active
    /// </summary>
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

    /// <summary>
    /// Check if current placement for the indicator is a valid horizontal plane
    /// </summary>
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
