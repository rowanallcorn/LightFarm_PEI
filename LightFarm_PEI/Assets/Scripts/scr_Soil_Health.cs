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
        //decreases all but rotation
        DecreaseWater();
        DecreaseMinerals();
        DecreaseFertilizer();
    }


    public void DecreaseWater() {
        if(ValueGreaterThanZero(soilWater))
            soilWater -= decrementValue;
    }

    public void DecreaseFertilizer()
    {
        if (ValueGreaterThanZero(soilFertilizer))
            soilFertilizer -= decrementValue;
    }

    public void DecreaseMinerals() {
        if (ValueGreaterThanZero(soilMinerals))
            soilMinerals -= decrementValue;
    }

    public void DecreaseRotation() {
        if (ValueGreaterThanZero(soilRotation))
            soilRotation -= decrementValue;
    }

    //increases
    public void IncreaseHealth()
    {
        //increases all but rotation
        IncreaseWater();
        IncreaseFertilizer();
        IncreaseMinerals();
    }


    public void IncreaseWater()
    {
        if (!ValueAtMax(soilWater))
            soilWater += incrementValue;
    }

    public void IncreaseFertilizer()
    {
        if (!ValueAtMax(soilFertilizer))
            soilFertilizer += incrementValue;
    }

    public void IncreaseMinerals()
    {
        if (!ValueAtMax(soilMinerals))
            soilMinerals += incrementValue;
    }

    public void IncreaseRotation()
    {
        //if not at max value
        if(!ValueAtMax(soilRotation))
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

        soilFertilizer = 3;
        soilWater = 3;
        soilMinerals = 3;
        //rotation starts high, and decreases each wrong rotation
        soilRotation = maxValue;

    }

    private bool ValueGreaterThanZero(int value) {
        if (value > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ValueAtMax(int value)
    {
        if (value == maxValue)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
