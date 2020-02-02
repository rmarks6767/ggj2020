using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{

    public class CellBlock : Floor
    {
        private Cell[] cells;
        private int maxCells;
        public GameObject[] cellLocations;

        public int MaxCells
        {
            get
            {
                return maxCells;
            }
        }

        public List<Cell> Cells
        {
            get
            {
                return cells.ToList();
            }
        }

        public override void Start()
        {
            buildingType = BuildingType.containment;
            maxRoomTier = 3;
            maxStaff = 2;
            maxCells = 3;
            cells = new Cell[3] 
            {
                new Cell(DangerLevel.safe, int.Parse(base.FloorNumber+""+0), gameObject, 0),
                new Cell(DangerLevel.safe, int.Parse(base.FloorNumber+""+1), gameObject, 1),
                new Cell(DangerLevel.safe, int.Parse(base.FloorNumber+""+2), gameObject, 2),
            };
            currentRoomTier = 0;

            base.Start();
        }
    }
}
