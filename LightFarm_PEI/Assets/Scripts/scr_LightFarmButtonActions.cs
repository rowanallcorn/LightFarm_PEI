﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LightFarmButtonActions : scr_abs_LightFarmButton
{

    //public scr_Inventory_Manager myInventory;

    public int SeedAmount = 0;
    public int IncrementDecermentAmount = 0;



    protected override void OnClick()
    {
        // tells the button what to do when clicked.
        SeedAmount += IncrementDecermentAmount;
        //myInventory.potatoSeeds = SeedAmount;
        Debug.Log(SeedAmount);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
