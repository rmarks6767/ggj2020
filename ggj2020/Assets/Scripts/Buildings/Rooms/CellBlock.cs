using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class CellBlock : Room
    {
        private BuildingType building;
        private Cell[] cells;
        private int maxCells;
        private int maxStaff;
        private int incrementingValue;
        private List<Staff> workingStaff;

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

        public CellBlock(BuildingType building)
        {
            this.building = building;
            maxCells = 3;
            cells = new Cell[maxCells];

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell(DangerLevel.safe);
            }
        }

        public Staff FindStaff(string removeName)
        {
            Staff staffStorage;

            for (int i = 0; i < workingStaff.Count; i++)
            {
                if (removeName == workingStaff[i].name)
                {
                    staffStorage = workingStaff[i];
                    return staffStorage;
                }
            }

            return null;
        }
    }
}
