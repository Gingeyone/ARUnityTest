using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using System;

/// <summary>
/// A controller that handles the UI buttons that decide which if any of the colour selection menus will be put on screen.
/// </summary>

public class UIController : MonoBehaviour
{

    public Animator anim_eyeUIControl; // Camera Window
    public Animator anim_shoeUIControl; // Camera Window

    public TMP_Text tMP_Text;
    public DistanceCheckingForWalking distanceCheckingForWalking;

    public void Start()
    {
        distanceCheckingForWalking = GameObject.Find("Girl_FBX2020_Prefab(Clone)").GetComponentInChildren<DistanceCheckingForWalking>();
    }


    public void Btn_eyeButton()
    {
        if (anim_eyeUIControl.GetBool("isOn") == false)
        {
            anim_eyeUIControl.SetBool("isOn", true);
            anim_shoeUIControl.SetBool("isOn", false);
        }
        else
        {
            anim_eyeUIControl.SetBool("isOn", false);
            anim_shoeUIControl.SetBool("isOn", false);
        }

    }
    public void Btn_shoeButton()
    {
        if (anim_shoeUIControl.GetBool("isOn") == false)
        {
            anim_eyeUIControl.SetBool("isOn", false);
            anim_shoeUIControl.SetBool("isOn", true);
        }
        else
        {
            anim_eyeUIControl.SetBool("isOn", false);
            anim_shoeUIControl.SetBool("isOn", false);
        }

    }

    public void Update()
    {
        //Update the debug UI to show the distance between the camera and the Model

        

            tMP_Text.text = "Current Distance: " + distanceCheckingForWalking.currentDistanceRounded;

        //currentDistance = Vector3.Distance(distanceCube.transform.position, transform.position);
        //currentDistanceRounded = Mathf.Round(currentDistance * 100) / 100;

    }



}
