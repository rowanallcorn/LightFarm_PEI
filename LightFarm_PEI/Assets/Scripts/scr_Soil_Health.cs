using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Soil_Health : MonoBehaviour
{
    //variables affecting soil health
    public int soilWater, soilFertilizer, soilMinerals, soilRotation;

    public string lastCrop = "", lastCropFamily ="";

    //what to lower stats by
    public int decrementValue = 5;
    //what to raise stats by
    public int incrementValue = 5;
    private int maxValue = 25;

    // Start is called before the first frame update
    void Start()
    {
        MaxOutStats();
    }

    //decreases
    public void DecreaseHealth() {
        DecreaseWater();
        DecreaseMinerals();
        DecreaseFertilizer();
    }


    public void DecreaseWater() {

    }

    public void DecreaseFertilizer()
    {

    }

    public void DecreaseMinerals() {

    }

    public void DecreaseRotation() {
        soilRotation-= decrementValue;
    }

    //increases
    public void IncreaseHealth()
    {
        IncreaseWater();
        IncreaseFertilizer();
        IncreaseMinerals();
    }


    public void IncreaseWater()
    {

    }

    public void IncreaseFertilizer()
    {

    }

    public void IncreaseMinerals()
    {

    }

    public void IncreaseRotation()
    {
        soilRotation += incrementValue;
    }


    public void CheckRotation(string currentCrop, string currentCropFamily)
    {
        //if current crop growing is the exact same crop as last
        if(currentCrop == lastCrop)
        {
            DecreaseRotation();
        }


        //if current crop is the same crop family as last
        if (currentCropFamily == lastCropFamily)
        {
            DecreaseRotation();
        }

    }

    public void MaxOutStats() {
        soilWater = maxValue;
        soilFertilizer = maxValue;
        soilMinerals = maxValue;
        soilRotation = maxValue;

    }
}
