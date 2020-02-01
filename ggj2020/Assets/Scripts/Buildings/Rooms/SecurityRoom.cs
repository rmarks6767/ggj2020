using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class SecurityRoom : Room
    {
        private int maxStaff;
        private int roomTier;
        private int maxRoomTier;

        private List<SecurityGuard> residentGuards;

        private BuildingType building;

        public SecurityRoom(BuildingType building) : base(building)
        {
            this.building = building;

            maxRoomTier = 3;

            residentGuards = new List<SecurityGuard>();

            maxStaff = 2;
            roomTier = 0;
        }

        /// <summary>
        /// If the staff adding is invalid will return false
        /// </summary>
        /// <returns></returns>
        public bool AddStaff(SecurityGuard newStaff)
        {
            if (maxStaff == (residentGuards.Count))
            {
                return false;
            }

            residentGuards.Add(newStaff);
            return true;
        }

    }

}