using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts
{

    public class Research : Buildings
    {
        public override void Start()
        {
            base.Start();
            buildingName = "Research";
            maxFloors = 6;
            floors.Add(Instantiate(GameManager.Instance.researchRoomPrefab, GameManager.Instance.screenLocation));
        }

        public override bool AddFloor()
        {
            if(floorCount < maxFloors)
            {
                floors.Add(Instantiate(GameManager.Instance.researchRoomPrefab, GameManager.Instance.screenLocation));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
