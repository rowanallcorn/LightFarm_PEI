using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Inventory_Manager : MonoBehaviour
{
    public enum SeedType {Potato, Pea, Cauliflower, Winterwheat, Blueberry };

    public enum ToolType {Basket, Hoe, Wateringcan, Fertilizer, Minerals };

    public SeedType seedState;
    public ToolType toolState;

    [SerializeField]
    //growing plot seeds
    //Potato Family.
    public int potatoSeeds = 0;
    public Text PotatoSeedsAmountText;

    //Legumes Family.
    public int peaSeeds = 0;
    public Text PeaSeedsAmountText;

    //Brassicas Family.
    public int cauliflowerSeeds = 0;
    public Text CauliflowerSeedsAmountText;

    //Cover Crop.
    public int winterWheatSeeds = 0;
    public Text WinterWheatSeedsAmountText;

    //hedge seeds
    public int blueBerryBushSeeds = 0;
    public Text BlueBerryBushSeedsAmountText;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        PotatoSeedsAmountText.text = potatoSeeds.ToString();
        PeaSeedsAmountText.text = peaSeeds.ToString();
        CauliflowerSeedsAmountText.text = cauliflowerSeeds.ToString();
        WinterWheatSeedsAmountText.text = winterWheatSeeds.ToString();
        BlueBerryBushSeedsAmountText.text = blueBerryBushSeeds.ToString();
 

    }

    ////simple increase and decrease functions used for ui buttons
    //public void IncreasePotatoSeedCount()
    //{
    //    potatoSeeds++;
    //}
    //public void DecreasePotatoSeedCount()
    //{
    //    if(potatoSeeds > 0)
    //    {
    //        potatoSeeds--;
    //    }
    //    else { potatoSeeds = 0; }
        
    //}


    //public void IncreasePeaSeedCount()
    //{
    //    peaSeeds++;
    //}
    //public void DecreasePeaSeedCount()
    //{
    //    if (peaSeeds > 0)
    //    {
    //        peaSeeds--;
    //    }
    //    else { peaSeeds = 0; }

    //}


    //public void IncreaseCauliflowerSeedCount()
    //{
    //    cauliflowerSeeds++;
    //}
    //public void DecreaseCauliflowerSeedCount()
    //{
    //    if (cauliflowerSeeds > 0)
    //    {
    //        cauliflowerSeeds--;
    //    }
    //    else { cauliflowerSeeds = 0; }

    //}


    //public void IncreaseWinterWheatSeedCount()
    //{
    //    winterWheatSeeds++;
    //}
    //public void DecreaseWinterWheatSeedCount()
    //{
    //    if (winterWheatSeeds > 0)
    //    {
    //        winterWheatSeeds--;
    //    }
    //    else { winterWheatSeeds = 0; }

    //}


    //public void IncreaseBlueBerrySeedCount()
    //{
    //    blueBerryBushSeeds++;
    //}
    //public void DecreaseBlueBerrySeedCount()
    //{
    //    if (blueBerryBushSeeds > 0)
    //    {
    //        blueBerryBushSeeds--;
    //    }
    //    else { blueBerryBushSeeds = 0; }
    //}
}
