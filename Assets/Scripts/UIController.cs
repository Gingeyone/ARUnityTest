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

    public Animator anim_eyeUIControl; // Animator for the Eye colour change menu UI
    public Animator anim_shoeUIControl; // Animator for the Shoe colour change menu UI


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

}
