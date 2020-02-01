using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Floor : MonoBehaviour
    {
        private BuildingType building;
        private int floorNumber;

        private Room floorRoom;


        /// <summary>
        /// The room that is held in the floor
        /// </summary>
        public Room FloorRoom
        {
            get { return floorRoom; }
            set { floorRoom = value; }
        }

        /// <summary>
        /// Type of this floor's building
        /// </summary>
        public BuildingType Building
        {
            get { return building; }
        }

        /// <summary>
        /// Current number of the floor
        /// </summary>
        public int FloorNumber
        {
            get { return floorNumber; }
        }

        public Floor(BuildingType buildingType)
        {
            building = buildingType;

            switch (building)
            {
                case BuildingType.containment:
                    floorRoom = new CellBlock(building);
                    break;

                case BuildingType.research:
                    floorRoom = new ResearchRoom(building);
                    
                    break;

                case BuildingType.security:
                    floorRoom = new SecurityRoom(building);
                    break;
            }
        }


    }
}
