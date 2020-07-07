using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Inventory_Manager : MonoBehaviour
{
    [SerializeField]
    //growing plot seeds
    public int potatoSeeds;

    //hedge seeds
    public int blueBerryBushSeeds;


    //Tools
    public bool waterCan;
    public bool harvestingBasket;
    public bool hoe;
    public bool pesticides;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //simple increase and decrease functions used for ui buttons
    void IncreasePotatoSeedCount()
    {
        potatoSeeds++;
    }

    void DcreasePotatoSeedCount()
    {
        potatoSeeds--;
    }

    void IncreaseBlueBerrySeedCount()
    {
        blueBerryBushSeeds++;
    }

    void DcreaseBlueBerrySeedCount()
    {
        blueBerryBushSeeds--;
    }
}
