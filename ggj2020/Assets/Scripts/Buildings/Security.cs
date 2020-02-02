using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Security : Buildings
    {
        public override void Start()
        {
            base.Start();
            buildingName = "Security";
            maxFloors = 6;
            floors.Add(Instantiate(GameManager.Instance.securityRoomPrefab, GameManager.Instance.screenLocation));
        }

        public override bool AddFloor()
        {
            if (floorCount < maxFloors)
            {
                floors.Add(Instantiate(GameManager.Instance.securityRoomPrefab, GameManager.Instance.screenLocation));
                GameObject.FindGameObjectWithTag("BuildingDisplay").GetComponent<BuildingDisplayManager>().UpgradeBuilding((int)BuildingType.security);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
