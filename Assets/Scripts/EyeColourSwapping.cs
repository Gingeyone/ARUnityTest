using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class EyeColourSwapping : MonoBehaviour
{
    [SerializeField]
    public Material[] eyeColourMaterials = new Material[4];
    

    public GameObject leftEyeModel;
    public GameObject rightEyeModel;



    void Start()
    {

        //once a model is loaded attatch the eye parts for swapping
        
        
    }

    void Update()
    {
        
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


        }
        else
        {
            Debug.Log("This is the same as the current eye colour. Do Nothing");
            return;
        }


    }




}
