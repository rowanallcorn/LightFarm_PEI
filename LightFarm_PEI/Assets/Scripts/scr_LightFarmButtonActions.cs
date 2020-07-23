using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LightFarmButtonActions : scr_abs_LightFarmButton
{

    public Inventory myInventory;
    public enum SeedType { Potato, Pea, Cauliflower, Winterwheat, Blueberry };

    public enum ToolType { Basket, Hoe, Wateringcan, Fertilizer, Minerals };

    public SeedType seedState;
    public ToolType toolState;

    
    public int IncrementDecermentAmount = 0;
    public float seedCost = 0;



    protected override void OnClick()
    {
        // tells the button what to do when clicked.
       


        switch (seedState)
        {
            case SeedType.Potato:
                //do potatostuff here
                myInventory.potatoSeeds += IncrementDecermentAmount;
               
                break;

            case SeedType.Pea:
                //do pea stuff here.
                myInventory.peaSeeds += IncrementDecermentAmount;
                break;

            case SeedType.Cauliflower:
                //do califlower stuff here.
                myInventory.cauliflowerSeeds += IncrementDecermentAmount;
                break;

            case SeedType.Winterwheat:
                //do winterwheat stuff here.
                myInventory.winterWheatSeeds += IncrementDecermentAmount;
                break;

            case SeedType.Blueberry:
                //do blueberry seed stuff here.
                myInventory.blueBerryBushSeeds += IncrementDecermentAmount;
                break;
        }


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
