using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Crop_Controller : MonoBehaviour
{

    //whether the crop has finished growing
    public bool finishedGrowing;


    void Start()
    {
        //FOR TESTING
        //set the time for crop to grow
        GetComponent<scr_Crop_Growth>().timeToGrow = 5f;
        GetComponent<scr_Crop_Growth>().StartGrowth();
    }

    void Update()
    {
        //update plant growth
        GetComponent<scr_Crop_Growth>().Growing();
    }

    private void OnMouseDown()
    {
        //FOR TESTING
        //destroys the object once it's fully grown
        if (finishedGrowing)
        {
            Destroy(this.gameObject);
            Debug.Log("Crop harvested.");
        }
        else
        {
            //time left to grow
            Debug.Log("Wait " + GetComponent<scr_Crop_Growth>().timeToGrow.ToString("0") + "s.");
        }
    }
}
