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

    public GameObject cropModel;

    void Start()
    {
        sc_CropGrowth = GetComponent<scr_Crop_Growth>();

        InitializeCrop();

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

            //TODO Text later
           // Debug.Log(this.name + " Harvested.");

            //will implement later
            CalculateQuality();

            //TODO
            //Get yield amount based on quiality

            //TODO
            //Decrement soil health as crop is harvested / used soil
            //maybe on destroy??

            //ANIM TESTING
            GetComponentInParent<Animator>().Play("anim_Crop_Harvest");
            Destroy(this.gameObject, .3f);
        }
        else
        {
            //TODO text later
            //time left to grow
            Debug.Log("Wait " + GetComponent<scr_Crop_Growth>().timeToGrow.ToString("0") + "s.");
        }

    }

    private void CalculateQuality() {

        //TODO
        //based on soil health stats > crop Quality
        //use crop quality to give yield, and grade
        //higher quality = better

        //if crop quality total (4 stats added) if over a certain level, it's of higher quality
        if(cropQuality > 15){
            Debug.Log("(A) " + this.name + " Harvested.");

        }
        else if(cropQuality> 10){
            Debug.Log("(B) " + this.name + " Harvested." );

        }
        else if (cropQuality > 5){
            Debug.Log("(C) " + this.name + " Harvested.");

        }
        else if (cropQuality <= 5)
        {
            Debug.Log("(D) " + this.name + " Harvested.");

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
        cropModel = Instantiate(data.models[0]) as GameObject;
        cropModel.transform.position = transform.position;
        cropModel.transform.position += new Vector3(0f, .3f, 0f);

        //set as child of prefab
        cropModel.transform.parent = transform;

        //activate crop
        gameObject.SetActive(true);
    }

    public void ChangeCropModel(int stage) {
        //set crop model
        GameObject newCropModel = Instantiate(data.models[stage]) as GameObject;
        newCropModel.transform.position = transform.position;

        //if mid stage, sprout crop
        if(stage == 1 && data.isFromSprout)
        {
            //smaller size
            newCropModel.transform.localScale -= new Vector3(50f, 50f, 50f);

        }

        //set as child of prefab
        newCropModel.transform.parent = transform;

        Destroy(cropModel);

        //activate crop
        newCropModel.SetActive(true);

        cropModel = newCropModel;
    }

    //TODO
    //Decrement soil health as crop is harvested / used soil
    private void OnDestroy()
    {
        //decrease soil elements on harvest
        sc_SoilHealth.DecreaseHealth();
    }
}
