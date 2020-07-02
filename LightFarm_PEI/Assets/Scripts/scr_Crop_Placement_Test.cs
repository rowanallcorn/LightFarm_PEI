using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Crop_Placement_Test : MonoBehaviour
{
    
    //FOR TESTING
    public GameObject preCrop;

    public void SpawnCrop(Vector3 spawnPoint) {

        GameObject cropTestObj = Instantiate(preCrop);
        cropTestObj.transform.position = spawnPoint + Vector3.up;
       // cropTestObj.transform.position = transform.position + Vector3.up;

    }

}
