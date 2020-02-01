using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ResearchRoom : Room
    {
        private BuildingType building;

        public ResearchRoom(BuildingType building) : base(building)
        {
            this.building = building;
        }
    }
}
