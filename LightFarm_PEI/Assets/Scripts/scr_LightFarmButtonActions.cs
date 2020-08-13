using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LightFarmButtonActions : scr_abs_LightFarmButton
{
    //Using myInventory to grab the seed information and then apply it.
    public Inventory myInventory;

    //Enums as a way to tell the button which seed or tool to effect when pressed.
    public enum SeedType { Potato, Pea, Cauliflower, Winterwheat, Blueberry };

    public enum ToolType { Basket, Hoe, Wateringcan, Fertilizer, Minerals };

    public SeedType seedState;
    public ToolType toolState;

    //The amount the button should Increment or decrement the seed by.
    public int IncrementDecermentAmount = 0;
    //Each seed will have a cost eventually but this feature was not finished and needs to be continued.
    public float seedCost = 0;



    protected override void OnClick()
    {
        //This increments of decrements the seed depending which numbers are applied to the variables in the inspector.


        switch (seedState)
        {
            case SeedType.Potato:
               
                myInventory.potatoSeeds += IncrementDecermentAmount;
               
                break;

            case SeedType.Pea:
               
                myInventory.peaSeeds += IncrementDecermentAmount;
                break;

            case SeedType.Cauliflower:
              
                myInventory.cauliflowerSeeds += IncrementDecermentAmount;
                break;

            case SeedType.Winterwheat:
            
                myInventory.winterWheatSeeds += IncrementDecermentAmount;
                break;

            case SeedType.Blueberry:
                
                myInventory.blueBerryBushSeeds += IncrementDecermentAmount;
                break;
        }


    }
}
