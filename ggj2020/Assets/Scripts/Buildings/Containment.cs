﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Containment : Buildings
    {
        // Max ammount of floors and cells possible in the building 
        private int maxFloors;
        private int maxCells;
        private int floorCount;

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
            
            floors[0] = new Floor(BuildingType.containment);
            floorCount = 1;
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

        /// <summary>
        /// Returns False if floor cannot be added.
        /// </summary>
        /// <returns></returns>
        public override bool AddFloor()
        {
            if (floorCount == maxFloors)
            {
                return false;
            }

            floors[floorCount - 1] = new Floor(BuildingType.containment);
            floorCount++;
            return true;
           
        }

        /// <summary>
        /// Looks through entire building to find staff
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Staff FindStaff(int id)
        {
            CellBlock roomStorage;
            Staff securityStorage;
            for (int i = 0; i < floorCount; i++)
            {
                roomStorage = (CellBlock)floors[i].FloorRoom;
                securityStorage = roomStorage.FindStaff(id);
                if (securityStorage != null)
                {
                    return securityStorage;
                }
            }

            return null;
        }
    }
}