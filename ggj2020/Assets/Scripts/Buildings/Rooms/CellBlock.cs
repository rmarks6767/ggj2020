using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class CellBlock : Room
    {
        private BuildingType building;

        public CellBlock(BuildingType building)
        {
            this.building = building;
        }
    }
}
