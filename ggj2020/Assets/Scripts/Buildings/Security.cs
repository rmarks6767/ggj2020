﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Security : Buildings
    {
        // Max ammount of floors possible in the building 
        private int maxFloors;
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
        public Security(int maxFloors = 5)
        {
            this.maxFloors = maxFloors;
            floors = new Floor[maxFloors];

            floors[0] = new Floor(BuildingType.security);
            floorCount = 1;
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

            floors[floorCount - 1] = new Floor(BuildingType.security);
            return true;

        }
    }
}
