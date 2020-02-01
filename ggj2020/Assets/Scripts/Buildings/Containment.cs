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

        private Floor[] floors;

        /// <summary>
        /// Array of all the floors in the building
        /// </summary>
        public Floor[] Floors
        {
            get { return floors; }
            set { floors = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFloors">Max floors per building</param>
        /// <param name="maxCells">Max cells per floor</param>
        public Containment(int maxFloors = 5, int maxCells = 3)
        {
            this.maxFloors = maxFloors;
            this.maxCells = maxCells;
            floors = new Floor[maxFloors];
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
            //if(
            //Placeholder return
            return false;
        }

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