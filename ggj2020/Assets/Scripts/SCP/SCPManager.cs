using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SCPManager : MonoBehaviour
{
    List<SCP> scips;
    int rCount; //researcher count in the entire facility
    int sCount; //security count in the entire facility
    public Containment building;

    public int ResearcherCount
    {
        get
        {
            return rCount;
        }
        set
        {
            rCount = value;
        }
    }

    public int SecurityCount
    {
        get
        {
            return sCount;
        }
        set
        {
            sCount = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scips = new List<SCP>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScip()
    {
        /**
         * Add the SCP to the list
         * generate a random terrain difficulty
         */
    }

    public void AddScip(SCP scip)
    {
        /**
         * Add the SCP to the list
         * generate a random terrain difficulty
         */
    }

    public void CaptureSCP(string name, Cell cell)
    {
        for (int i = 0; i < scips.Count; i++)
        {
            if (scips[i].Name == name)
            {
                if (scips[i].AttemptCapture((int)Random.Range(0, 21)))
                {
                    cell.ContainSCP(scips[i]);
                    scips.RemoveAt(i);
                    //remove the SCP from the list and add it to an empty cell
                }
                else
                {
                    scips[i].CaptureDifficulty += 10;
                    //remove some security
                }
                return;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>a list of every empty cell in the containment building</returns>
    public List<Cell> FindOpenCells()
    {
        List<Cell> tempList = new List<Cell>();
        CellBlock tempCellBlock;
        foreach (Floor block in building.Floors)
        {
            if (block.FloorRoom is CellBlock)
            {
                tempCellBlock = (CellBlock)block.FloorRoom;
                foreach (Cell cell in tempCellBlock.Cells)
                {
                    if (cell.CellInhabitant == null)
                    {
                        tempList.Add(cell);
                    }
                }
            }
        }
        return tempList;
    }
}
