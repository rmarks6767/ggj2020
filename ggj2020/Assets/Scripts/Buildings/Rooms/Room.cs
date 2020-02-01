using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{


    /// <summary>
    /// Room Class to be polymorphed into other rooms
    /// </summary>
    public class Room : MonoBehaviour
    {
        private BuildingType building;

        public Room(BuildingType building)
        {
            this.building = building;
        }

    }
}
