using System.Collections;
using System.Collections.Generic;
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

        public Cell[] Cells
        {
            get
            {
                return cells;
            }
        }

        public override void Start()
        {
            buildingType = BuildingType.containment;
            maxRoomTier = 3;
            maxStaff = 2;
            maxCells = 3;
            cells = new Cell[3];
            currentRoomTier = 0;

            base.Start();
        }
    }
}
