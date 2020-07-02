using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Grid : MonoBehaviour
{
    public int gridRows, gridColumns;
    private float gridY = 0.5f;

    public int cellSize;

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
        for (int x = 0; x < gridRows; x += cellSize)
        {
            for (int z = 0; z < gridColumns; z += cellSize)
            {
                gridCells[x, z] = new Vector3(x, gridY, z);
            }
        }

    }


    public Vector3 GetPointOnGrid(Vector3 hitPoint)
    {
            //check for matching spot it array
            for (int x = 0; x < gridRows; x += cellSize)
            {
                for (int z = 0; z < gridColumns; z += cellSize)
                {

                if (z != 0 && x != 0)
                {
                    if (hitPoint.z < z && hitPoint.z > z - cellSize)
                    {
                        //if hit matches both row and col 
                        if (hitPoint.x < x && hitPoint.x > x - cellSize)
                        {

                            //return spot
                            //return gridCells[x, z];

                            //return spot, but centred within grid cell
                             return GetCentreOfSpot(gridCells[x, z]);
                        }
                    }
                }
                else
                {
                    if (hitPoint.z < z && hitPoint.z > 0)
                    {
                        //if hit matches both row and col 
                        if (hitPoint.x < x && hitPoint.x > 0)
                        {

                            //return spot
                            //return gridCells[x, z];

                            //return spot, but centred within grid cell
                             return GetCentreOfSpot(gridCells[x, z]);
                        }
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
        Vector3 midCell = new Vector3(newX, gridY, newZ);

        //return new middle point
        return midCell;

    }

    //Visual Editor Reference
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < gridRows; x += cellSize)
        {
            for (float z = 0; z < gridColumns; z += cellSize)
            {
                Gizmos.DrawSphere(new Vector3(x, gridY, z), 0.1f);
            }

        }
    }*/
}
