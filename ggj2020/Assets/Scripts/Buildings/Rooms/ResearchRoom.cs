using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ResearchRoom : Floor
    {
        public List<GameObject> onFloorStaff = new List<GameObject>();

        public override void Start()
        {
            buildingType = BuildingType.research;
            maxRoomTier = 3;
            maxStaff = 2;
            currentRoomTier = 0;

            base.Start();
        }
    }
}
