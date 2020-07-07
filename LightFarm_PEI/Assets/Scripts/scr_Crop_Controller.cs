using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Crop_Controller : MonoBehaviour
{
    //whether the crop has finished growing
    public bool finishedGrowing;

    private scr_Crop_Growth sc_CropGrowth;

    void Start()
    {
        sc_CropGrowth = GetComponent<scr_Crop_Growth>();

        //FOR TESTING
        //set the time for crop to grow
        sc_CropGrowth.timeToGrow = 5f;
        sc_CropGrowth.StartGrowth();
    }

    void Update()
    {
        //update plant growth
        GetComponent<scr_Crop_Growth>().Growing();
    }

    private void OnMouseDown()
    {
        //FOR TESTING
        if (finishedGrowing)
        {
            Debug.Log("Crop ready to be harvested.");
        }
        else
        {
            //time left to grow
            Debug.Log("Wait " + GetComponent<scr_Crop_Growth>().timeToGrow.ToString("0") + "s.");
        }
    }
}
