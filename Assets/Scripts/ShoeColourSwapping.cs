using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// Handles the Material swapping system for the Shoes on the Model
/// </summary>
public class ShoeColourSwapping : MonoBehaviour
{

    public Button enterModeButton;
    public Image imageUIBackground;

    [SerializeField]
    public Material[] shoeColourMaterials = new Material[4];
    public Color[] shoeColourUI = new Color[4];
    public Image currentColour;

    public GameObject leftShoeModel;
    public GameObject leftShoeLaceModel;
    public GameObject leftShoeTopModel;

    public GameObject rightShoeModel;
    public GameObject rightShoeLaceModel;
    public GameObject rightShoeTopModel;

    private void Start()
    {
        //once a model is loaded attach the shoe parts for swapping

        leftShoeModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/L_shoe_geo_grp/L_shoe_geo");
        leftShoeLaceModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/L_shoe_geo_grp/L_shoelace_geo");
        leftShoeTopModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/L_shoe_geo_grp/L_shoeTop_geo");

        rightShoeModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/R_shoe_geo_grp/R_shoe_geo");
        rightShoeLaceModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/R_shoe_geo_grp/R_shoelace_geo");
        rightShoeTopModel = GameObject.Find("Girl_FBX2020_Prefab(Clone)/Geometry/claire_model_grp/R_shoe_geo_grp/R_shoeTop_geo");

        currentColour.color = shoeColourUI[3];
    }

    public void Btn_ShoeSwap(int index)
    {
        if (rightShoeModel.GetComponent<SkinnedMeshRenderer>().material != shoeColourMaterials[index])
        {
            if (index > 3) return; //Checking that we are not over the list

            Debug.Log("This is a new shoe colour. Shoe Colour Changed");

            rightShoeModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            rightShoeLaceModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            rightShoeTopModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];


            leftShoeModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            leftShoeLaceModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];
            leftShoeTopModel.GetComponent<SkinnedMeshRenderer>().material = shoeColourMaterials[index];

            currentColour.color = shoeColourUI[index];
        }

    }


    public void Btn_EnterSelectMode()
    {
        imageUIBackground.transform.position = new Vector3(0, 0, 0);
    }

}
