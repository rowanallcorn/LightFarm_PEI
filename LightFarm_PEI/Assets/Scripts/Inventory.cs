using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//**********Notes*************
// main use for this script is just to output the seeds value to text and show it on the HUD/UI.
public class Inventory : MonoBehaviour
{
   
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

    public int TotalAmoutofMoney = 0;


    // Update is called once per frame
    void Update()
    {
       
        PotatoSeedsAmountText.text = potatoSeeds.ToString();
        PeaSeedsAmountText.text = peaSeeds.ToString();
        CauliflowerSeedsAmountText.text = cauliflowerSeeds.ToString();
        WinterWheatSeedsAmountText.text = winterWheatSeeds.ToString();
        BlueBerryBushSeedsAmountText.text = blueBerryBushSeeds.ToString();


    }
}
