using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheckingForWalking : MonoBehaviour
{
    public float distanceToCheck = 1.5f;
    public float currentDistance = 0.0f;
    public GameObject distanceCube;
    public Animator animController; // Camera Window

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentDistance = Vector3.Distance(distanceCube.transform.position, transform.position);

        if (currentDistance > distanceToCheck)
        {
            //turn on walking, move towards block
            animController.SetBool("farAway", true);

        }
        else
        {
            animController.SetBool("farAway", false);
        }


        if (currentDistance > 5)
        {

            animController.SetBool("farAway", false);
        }

    }
}
