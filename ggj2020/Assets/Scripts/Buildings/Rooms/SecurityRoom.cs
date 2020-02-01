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

        private BuildingType building;

        public SecurityRoom(BuildingType building) : base(building)
        {
            this.building = building;

            maxRoomTier = 3;

            maxStaff = 2;
            roomTier = 0;
        }

        
    }

}