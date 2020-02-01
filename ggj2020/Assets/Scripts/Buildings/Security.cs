using System.Collections;
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
            floorCount++;
            return true;

        }


        /// <summary>
        /// Looks through entire building to find a security guard
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SecurityGuard FindStaff(string name)
        {
            SecurityRoom roomStorage;
            SecurityGuard securityStorage;
            for (int i = 0; i < floorCount; i++)
            {
                roomStorage = (SecurityRoom)floors[i].FloorRoom;
                securityStorage = roomStorage.FindStaff(name);
                if (securityStorage != null)
                {
                    return securityStorage;
                }
            }

            return null;
        }

        /// <summary>
        /// Looks through entire building to find a security guard
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SecurityGuard RemoveStaff(string name)
        {
            SecurityRoom roomStorage;
            SecurityGuard securityStorage;
            for (int i = 0; i < floorCount; i++)
            {
                roomStorage = (SecurityRoom)floors[i].FloorRoom;
                securityStorage = roomStorage.RemoveStaff(name);
                if (securityStorage != null)
                {
                    return securityStorage;
                }
            }

            return null;
        }
    }
}
