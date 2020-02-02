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
                new Cell(DangerLevel.safe),
                new Cell(DangerLevel.safe),
                new Cell(DangerLevel.safe),
            };
            currentRoomTier = 0;

            base.Start();
        }
    }
}
