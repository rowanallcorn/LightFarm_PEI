using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Crop_Controller : MonoBehaviour
{
    //whether the crop has finished growing
    public bool finishedGrowing;

    private scr_Crop_Growth sc_CropGrowth;
    private scr_Soil_Health sc_SoilHealth;

    public int cropQuality;

    //initialize crop
    public scr_Crop_Data data;

    //for rotation check
    public string cropFamily; 

    void Start()
    {
        sc_CropGrowth = GetComponent<scr_Crop_Growth>();

        InitializeCrop();

        //FOR TESTING
        //set the time for crop to grow
       // sc_CropGrowth.timeToGrow = 5f;
        sc_CropGrowth.StartGrowth();

        sc_SoilHealth = GetComponentInParent<scr_Soil_Health>();
        sc_SoilHealth.CheckRotation(this.name, cropFamily);

    }

    void Update()
    {
        //update plant growth
        GetComponent<scr_Crop_Growth>().Growing();

        CheckSoilQuality();
    }

    private void CheckSoilQuality()
    {
        //add all the soil variables together
        cropQuality = sc_SoilHealth.soilWater + sc_SoilHealth.soilFertilizer + sc_SoilHealth.soilMinerals + sc_SoilHealth.soilRotation;
    }


    public void HarvestCrop()
    {
        if (finishedGrowing)
        {
            //set soils last crop
            sc_SoilHealth.lastCrop = this.name;
            sc_SoilHealth.lastCropFamily = cropFamily;

            Debug.Log(this.name + " Harvested.");
            Destroy(this.gameObject);
        }
        else
        {
            //time left to grow
            Debug.Log("Wait " + GetComponent<scr_Crop_Growth>().timeToGrow.ToString("0") + "s.");
        }

    }

    //set crop variables based on scriptable object
    public void InitializeCrop() {
        //set crop name
        name = data.name;
        //set crop growth time
        sc_CropGrowth.timeToGrow = data.totalTimeGrowthSeconds;
        //plant family
        cropFamily = data.plantRotationFamily;

        //set crop model
        GameObject cropModel = Instantiate(data.model, transform.position, transform.rotation) as GameObject;
        //for tesing
        cropModel.transform.position -= new Vector3(0, .5f, 0);
        cropModel.transform.localScale = new Vector3(.25f, .45f, .25f);

        //set as child of prefab
        cropModel.transform.parent = transform;

        //activate crop
        gameObject.SetActive(true);
    }
}
