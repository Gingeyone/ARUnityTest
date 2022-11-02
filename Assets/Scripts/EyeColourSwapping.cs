using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using System;

public class EyeColourSwapping : MonoBehaviour
{

    public Button enterModeButton;
    public Image imageUIBackground;

    [SerializeField]
    public Material[] eyeColourMaterials = new Material[4];

    public Color[] eyeColourUI = new Color[4];
    public Image currentColour;

    public GameObject leftEyeModel;
    public GameObject rightEyeModel;




    void Start()
    {

        //once a model is loaded attatch the eye parts for swapping

        leftEyeModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/head_grp/L_eye_geo");
        rightEyeModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/head_grp/R_eye_geo");

        currentColour.color = eyeColourUI[0];


    }

    void Update()
    {
        
    }


    public void Btn_EnterSelectMode()
    {
        imageUIBackground.transform.position = new Vector3(0, 0, 0);


    }

    public void Btn_EyeSwap(int index)
    {
        //If eyes are not this colour, make them this colour

        if (rightEyeModel.GetComponent<SkinnedMeshRenderer>().material != eyeColourMaterials[index])
        {
            if (index > 3) return; //Checking the material is in the list

            Debug.Log("This is a new eye colour. Eye Colour Changed");

            rightEyeModel.GetComponent<SkinnedMeshRenderer>().material = eyeColourMaterials[index];
            leftEyeModel.GetComponent<SkinnedMeshRenderer>().material = eyeColourMaterials[index];

            currentColour.color = eyeColourUI[index];


        }
        else
        {
            Debug.Log("This is the same as the current eye colour. Do Nothing");
            return;
        }


    }


}
