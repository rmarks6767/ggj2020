using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class SecurityRoom : Room
    {
        private BuildingType building;

        public SecurityRoom(BuildingType building) : base(building)
        {
            this.building = building;
        }
    }

}