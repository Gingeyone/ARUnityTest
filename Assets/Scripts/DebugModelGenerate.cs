using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugModelGenerate : MonoBehaviour
{
    public EyeColourSwapping eyeColourSwapping;
    public ShoeColourSwapping shoeColourSwapping;

    public GameObject objectToPlace;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void PlaceObject()
    {
        Instantiate(objectToPlace, new Vector3(0, 0, 0), new Quaternion());
    }


    public void Btn_PlaceObject()
    {
        eyeColourSwapping.enabled = true;
        shoeColourSwapping.enabled = true;

        PlaceObject();

    }

}
