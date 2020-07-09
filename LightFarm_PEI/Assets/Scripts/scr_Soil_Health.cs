using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Soil_Health : MonoBehaviour
{
    //variables affecting soil health
    public int soilWater = 25,
        soilFertilizer = 25,
        soilMinerals = 25,
        soilRotation = 25;

    public string lastCrop = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DecreaseHealth() {

    }


    public void DecreaseWater() {

    }

    public void DecreaseFertilizer()
    {

    }

    public void DecreaseMinerals() {

    }

    public void DecreaseRotation() {
        soilRotation--;
    }


    public void CheckRotation(string currentCrop)
    {
        if(currentCrop == lastCrop)
        {
            DecreaseRotation();
        }

    }
}
