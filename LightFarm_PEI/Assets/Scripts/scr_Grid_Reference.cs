using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Grid_Reference : MonoBehaviour
{

    private scr_Grid sc_Grid;

    //FOR TESTING
    public GameObject pre_TilledSpot;
    public GameObject pre_Crop;

    // Start is called before the first frame update
    void Start()
    {
        sc_Grid = GetComponent<scr_Grid>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CheckPosition();
        }
    }

    void CheckPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //FOR TESTING
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.collider != null)
            {

                //only if hitting ground layer
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    //Get raycast's position as a point on the grid
                    TillSoil(sc_Grid.GetPointOnGrid(hit.point));
                }
                //only if hitting farming plot
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("FarmPlot"))
                {
                    PlantCrop(sc_Grid.GetPointOnGrid(hit.point));
                }
            }
        }
    }


    //FOR TESTING
    void TillSoil(Vector3 spawnPoint) {

        //tilled spot
        GameObject tilTestObj = Instantiate(pre_TilledSpot);
        tilTestObj.transform.position = spawnPoint;

    }

    void PlantCrop(Vector3 spawnPoint)
    {
        GameObject cropTestObj = Instantiate(pre_Crop);
        cropTestObj.transform.position = spawnPoint + Vector3.up;

    }


}
