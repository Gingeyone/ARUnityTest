using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class ShoeColourSwapping : MonoBehaviour
{

    public Button enterModeButton;
    public Image imageUIBackground;

    [SerializeField]
    public Material[] shoeColourMaterials = new Material[4];



    public GameObject leftShoeModel;
    public GameObject leftShoeLaceModel;
    public GameObject leftShoeTopModel;

    public GameObject rightShoeModel;
    public GameObject rightShoeLaceModel;
    public GameObject rightShoeTopModel;

    private void Start()
    {
        //when model is loaded find the gameobjects here

        leftShoeModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/L_shoe_geo_grp/L_shoe_geo");
        leftShoeLaceModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/L_shoe_geo_grp/L_shoelace_geo");
        leftShoeTopModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/L_shoe_geo_grp/L_shoeTop_geo");

        rightShoeModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/R_shoe_geo_grp/R_shoe_geo");
        rightShoeLaceModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/R_shoe_geo_grp/R_shoelace_geo");
        rightShoeTopModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/R_shoe_geo_grp/R_shoeTop_geo");
    }

    public void Btn_ShoeSwap(int index)
    {
        //If eyes are not this colour, make them this colour

        if (rightShoeModel.GetComponent<SkinnedMeshRenderer>().material != shoeColourMaterials[index])
        {
            if (index > 3) return; //Checking the material is in the list

            Debug.Log("This is a new shoe colour. Shoe Colour Changed");

            rightShoeModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            rightShoeLaceModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            rightShoeTopModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];


            leftShoeModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            leftShoeLaceModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            leftShoeTopModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];


        }
        else
        {
            Debug.Log("This is the same as the current Shoe colour. Do Nothing");
            return;
        }


    }


    public void Btn_EnterSelectMode()
    {
        imageUIBackground.transform.position = new Vector3(0, 0, 0);


    }

}
