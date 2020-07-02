using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Grid : MonoBehaviour
{
    public int gridRows, gridColumns;

    public int cellSize = 1;

    private Vector3[,] gridCells;

    // Start is called before the first frame update
    void Start()
    {
        gridCells = new Vector3[gridRows, gridColumns];

        SetupGrid();

    }

    private void SetupGrid()
    {
        //Loops create/store all the Vector points on the grid, according to size
        for (int i = 0; i < gridRows; i += cellSize)
        {
            for (int x = 0; x < gridColumns; x += cellSize)
            {
                gridCells[i, x] = new Vector3(i, 0, x);
            }
        }

    }


    public Vector3 GetPointOnGrid(Vector3 hitPoint)
    {
        //check for matching spot it array
        for (int i = 0; i < gridRows; i += cellSize)
        {
            for (int x = 0; x < gridColumns; x += cellSize)
            {

                if (hitPoint.z < x && hitPoint.z > x - 1)
                {
                    //if hit matches both row and col 
                    if (hitPoint.x < i && hitPoint.x > i - 1)
                    {

                        //return spot
                        //return gridCells[i, x];

                        //return spot, but centred within grid cell
                        return GetCentreOfSpot(gridCells[i, x]);
                    }
                }

            }
        }

        //if nothing
        return Vector3.zero;


    }


    //Return the grid position
    private Vector3 GetCentreOfSpot(Vector3 hitPoint)
    {
        //get half the size
        float halfCell = cellSize / 2f;

        //get new positions (moved in by half size)
        float newX = hitPoint.x - halfCell;
        float newZ = hitPoint.z - halfCell;
        Vector3 midCell = new Vector3(newX, 0, newZ);

        //return new middle point
        return midCell;

    }
}
