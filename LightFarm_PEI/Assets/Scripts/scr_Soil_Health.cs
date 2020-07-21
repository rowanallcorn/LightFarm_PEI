using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Soil_Health : MonoBehaviour
{
    //variables affecting soil health
    public int soilWater, soilFertilizer, soilMinerals, soilRotation;

    public string lastCrop = "", lastCropFamily ="";

    //what to lower stats by
    public int decrementValue = 1;
    //what to raise stats by
    public int incrementValue = 1;
    private int maxValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        InitializeStats();
    }

    //decreases
    public void DecreaseHealth() {
        DecreaseWater();
        DecreaseMinerals();
        DecreaseFertilizer();
    }


    public void DecreaseWater() {
        soilWater -= decrementValue;
    }

    public void DecreaseFertilizer()
    {
        soilFertilizer -= decrementValue;
    }

    public void DecreaseMinerals() {
        soilMinerals -= decrementValue;
    }

    public void DecreaseRotation() {
        soilRotation -= decrementValue;
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
        soilWater += incrementValue;
    }

    public void IncreaseFertilizer()
    {
        soilFertilizer += incrementValue;
    }

    public void IncreaseMinerals()
    {
        soilMinerals += incrementValue;
    }

    public void IncreaseRotation()
    {
        //if less than max value
        if (soilRotation > maxValue)
        {
            soilRotation += incrementValue;
        }
    }


    public void CheckRotation(string currentCrop, string currentCropFamily)
    {
        //if current crop growing is the exact same crop as last
        if(currentCrop == lastCrop)
        {
            DecreaseRotation();
        }
        //if current crop is the same crop family as last
        else if (currentCropFamily == lastCropFamily)
        {
            DecreaseRotation();
        }
        else
        {
            IncreaseRotation();
        }

    }

    public void MaxOutAllStats() {
        soilWater = maxValue;
        soilFertilizer = maxValue;
        soilMinerals = maxValue;
        soilRotation = maxValue;
    }

    //starting stats
    private void InitializeStats() {

        soilFertilizer = 0;
        soilWater = 0;
        soilMinerals = 0;
        //rotation starts high, and decreases each wrong rotation
        soilRotation = maxValue;

    }
}
