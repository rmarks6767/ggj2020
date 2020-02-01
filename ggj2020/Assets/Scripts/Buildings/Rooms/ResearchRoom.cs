using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ResearchRoom : Room
    {
        private BuildingType building;

        public ResearchRoom(BuildingType building)
        {
            this.building = building;
        }
    }
}
