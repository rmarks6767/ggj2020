using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ResearchRoom : Room
    {
        private int maxStaff;
        private int roomTier;
        private int maxRoomTier;
        private int incrementingValue;

        private List<Researcher> residentResearchers;

        private BuildingType building;

        public ResearchRoom(BuildingType building) : base(building)
        {
            this.building = building;

            maxRoomTier = 3;
            incrementingValue = 2;

            residentResearchers = new List<Researcher>();

            maxStaff = 2;
            roomTier = 0;
        }

        /// <summary>
        /// If the staff adding is invalid will return false
        /// </summary>
        /// <returns></returns>
        public bool AddStaff(Researcher newStaff)
        {
            if (maxStaff == (residentResearchers.Count))
            {
                return false;
            }

            residentResearchers.Add(newStaff);
            return true;
        }

        /// <summary>
        /// If the upgrade is invalid will return false
        /// </summary>
        /// <returns></returns>
        public bool RoomUpgrade()
        {   
            if (roomTier == maxRoomTier)
            {
                return false;
            }
            roomTier++;
            maxStaff += incrementingValue;
   
        }


    }
}
