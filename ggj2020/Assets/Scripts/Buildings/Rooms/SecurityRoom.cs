using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class SecurityRoom : Floor
    {
        

        public override void Start()
        {
            buildingType = BuildingType.security;
            maxRoomTier = 3;
            maxStaff = 2;

            currentRoomTier = 0;
            base.Start();
        }
    }

}