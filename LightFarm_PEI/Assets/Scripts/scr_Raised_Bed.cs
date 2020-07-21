using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Raised_Bed : MonoBehaviour
{
    public List<GameObject> soilPlots;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlots();
    }

    //add each plot into list that's attached to raised bed object
    void InitializePlots() {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            soilPlots.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }


}
