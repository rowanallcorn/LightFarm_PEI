using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class scr_Crop_Data : ScriptableObject
{

    //total time to grow
    public float totalTimeGrowthSeconds;

    //3d model
    public GameObject[] models;

    //plant family, for future rotation stuff
    public string plantRotationFamily;

}
