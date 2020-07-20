using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Crop_Growth : MonoBehaviour
{
    //total time it takes to grow, will deplete as it grows
    public float timeToGrow;

    //FOR TESTING, mock stages of growth
    //when crop is halfway through growth
    private float halfTimeToGrow;
    private bool halfDoneGrowing;

    public void Growing()
    {

        //if crop has not finished growing
        if (!GetComponent<scr_Crop_Controller>().finishedGrowing)
        {
            //if timer is still greater than 0
            if (timeToGrow > 0)
            {
                //decrement timer by time
                timeToGrow -= Time.deltaTime;
            }
            else
            {
                //once time runs out, crop has finished growing
                FinishedGrowing();
            }

            //FOR TESTING
            //if plant is half finished growing
            if (timeToGrow < halfTimeToGrow && !halfDoneGrowing)
            {
                MidGrowth();
            }
        }

    }

    //initialize variables
    public void StartGrowth()
    {
        halfTimeToGrow = timeToGrow / 2;
    }

    //crop is halfway through growth, grows a bit
    private void MidGrowth()
    {
        halfDoneGrowing = true;
        //FOR TESTING
        if (GetComponent<scr_Crop_Controller>().data.models[1] == null)
        {
            this.transform.localScale += new Vector3(.15f, .15f, .15f);
        }
        else {
            GetComponent<scr_Crop_Controller>().ChangeCropModel(1);
        }
    }

    //set plant as finished growing
    //later can change animations, etc
    private void FinishedGrowing()
    {
        //set growth finished to true
        GetComponent<scr_Crop_Controller>().finishedGrowing = true;

        //FOR TESTING
        if (GetComponent<scr_Crop_Controller>().data.models[2] == null)
        {
            this.transform.localScale += new Vector3(.15f, .15f, .15f);
        }
        else {
            GetComponent<scr_Crop_Controller>().ChangeCropModel(2);
        }

    }

    //decrease growing timer by fast forward amount
    public void FastForwardGrowth(float timeAddedInSeconds) {

        timeToGrow -= timeAddedInSeconds;

    }

}
