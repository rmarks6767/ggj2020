using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Containment : Buildings
    {
        // Max ammount of floors and cells possible in the building 
        private int maxFloors;
        private int maxCells;
        private int numberOfFloors;

        // number of cells (value) per floor (index)
        private int[] occupiedCellsPerFloor;

        /// <summary>
        /// [Floor #, Cell #]
        /// </summary>
        private Cell[,] containmentFloors; 
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFloors">Max floors per building</param>
        /// <param name="maxCells">Max cells per floor</param>
        public Containment(int maxFloors = 3, int maxCells = 6)
        {
            this.maxFloors = maxFloors;
            this.maxCells = maxCells;

            // Sets up counter for cells that are occupied on each floor
            occupiedCellsPerFloor = new int[maxFloors];
            for (int i = 0; i < maxFloors; i++)
            {
                occupiedCellsPerFloor[i] = 0;
            }


            containmentFloors = new Cell[maxFloors, maxCells];
            for(
        }

        /// <summary>
        /// Method return false if cell is invalid, returns true if succeeded
        /// </summary>
        /// <param name="floorNumber"></param>
        /// <param name="roomNumber"></param>
        /// <param name="newSCP"></param>
        /// <returns></returns>
        public bool AddSCP(int floorNumber, int roomNumber, SCP newSCP)
        {
            if(
        }

        public string Export

        public override void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}
