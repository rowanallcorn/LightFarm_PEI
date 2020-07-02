using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Grid_Reference : MonoBehaviour
{

    private scr_Grid sc_Grid;
    private scr_Crop_Placement_Test sc_Crop_Place_Test;

    // Start is called before the first frame update
    void Start()
    {
        sc_Grid = GetComponent<scr_Grid>();
        sc_Crop_Place_Test = GetComponent<scr_Crop_Placement_Test>();
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

            //Get raycast's position as a point on the grid
            sc_Crop_Place_Test.SpawnCrop(sc_Grid.GetPointOnGrid(hit.point));
        }
    }


}
