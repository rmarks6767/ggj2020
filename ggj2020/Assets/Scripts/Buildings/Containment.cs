using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Containment : Buildings
    {
        public override void Start()
        {
            base.Start();
            buildingName = "Containment";
            maxFloors = 6;
            floors.Add(Instantiate(GameManager.Instance.cellBlockPrefab, GameManager.Instance.screenLocation));
        }

        public override bool AddFloor()
        {
            if (floorCount < maxFloors)
            {
                floors.Add(Instantiate(GameManager.Instance.cellBlockPrefab, GameManager.Instance.screenLocation));
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method return false if cell is invalid, returns true if succeeded
        /// </summary>
        /// <param name="floorNumber"></param>
        /// <param name="roomNumber"></param>
        /// <param name="newSCP"></param>
        /// <returns></returns>
        public bool AddSCP(int floorNumber, int cellNumber, SCP newSCP)
        {
            if(floorNumber > floorCount ||
                cellNumber > 3 ||
                ((CellBlock)(floors[floorNumber].GetComponent<Floor>())).Cells[cellNumber].IsFilled)
            {
                return false;
            }
            else
            {
                ((CellBlock)(floors[floorNumber].GetComponent<Floor>())).Cells[cellNumber].ContainSCP(newSCP);
                return true;
            }
        }
    }
}