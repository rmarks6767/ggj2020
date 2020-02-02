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

        public Staff FindStaff(int id)
        {
            Staff staffStorage;

            for (int i = 0; i < workingStaff.Count; i++)
            {
                if (id == workingStaff[i].ID)
                {
                    staffStorage = workingStaff[i];
                    return staffStorage;
                }
            }

            return null;
        }

        /// <summary>
        /// Will return null if staff name doesnt exist on floor
        /// </summary>
        /// <param name="removeName"></param>
        /// <returns></returns>
        public Staff RemoveStaff(int id)
        {
            Staff staffStorage;

            for (int i = 0; i < workingStaff.Count; i++)
            {
                if (id == workingStaff[i].ID)
                {
                    staffStorage = workingStaff[i];
                    workingStaff.RemoveAt(i);
                    return staffStorage;
                }
            }

            return null;
        }
    }
}
