using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LightFarmButtonActions : scr_abs_LightFarmButton
{

    public scr_Inventory_Manager myInventory;
    public enum SeedType { Potato, Pea, Cauliflower, Winterwheat, Blueberry };

    public enum ToolType { Basket, Hoe, Wateringcan, Fertilizer, Minerals };

    public SeedType seedState;
    public ToolType toolState;

    public int SeedAmount = 0;
    public int IncrementDecermentAmount = 0;



    protected override void OnClick()
    {
        // tells the button what to do when clicked.
        SeedAmount += IncrementDecermentAmount;


        switch (seedState)
        {
            case SeedType.Potato:
                //do potatostuff here
                myInventory.potatoSeeds = SeedAmount;
                break;
            case SeedType.Pea:
                //do pea stuff here.
                myInventory.peaSeeds = SeedAmount;
                break;
            case SeedType.Cauliflower:
                //do califlower stuff here.
                myInventory.cauliflowerSeeds = SeedAmount;
                break;
            case SeedType.Winterwheat:
                //do winterwheat stuff here.
                myInventory.winterWheatSeeds = SeedAmount;
                break;
            case SeedType.Blueberry:
                //do blueberry seed stuff here.
                myInventory.blueBerryBushSeeds = SeedAmount;
                break;
        }

        switch (toolState)
        {
            case ToolType.Basket:

                break;
            case ToolType.Hoe:

                break;
            case ToolType.Wateringcan:

                break;
            case ToolType.Fertilizer:

                break;
            case ToolType.Minerals:

                break;
        }


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
