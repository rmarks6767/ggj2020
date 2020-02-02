using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public abstract class Buildings : MonoBehaviour
    {
        // Max ammount of floors possible in the building 
        protected int maxFloors;
        protected int floorCount;
        protected List<GameObject> floors;
        protected string buildingName;

        /// <summary>
        /// Array of all the floors in the building
        /// </summary>
        public List<GameObject> Floors
        {
            get { return floors; }
        }

        public string Name
        {
            get { return buildingName; }
        }

        public virtual void Start()
        {
            floors = new List<GameObject>();
            floorCount = 1;
        }

        /// <summary>
        /// Returns False if floor cannot be added.
        /// </summary>
        /// <returns></returns>
        public abstract bool AddFloor();

        public void RemoveFloor()
        {
            floors.RemoveAt(floors.Count - 1);
        }

        /// <summary>
        /// Looks through entire building to find a researcher
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Staff FindStaff(string name)
        {
            Staff output = null;
            for (int i = 0; i < floorCount; i++)
            {
                Staff tmp = floors[i].GetComponent<Floor>().FindStaff(name);
                if (tmp != null)
                {
                    output = tmp;
                    break;
                }
            }
            return output;
        }

        public Staff FindStaff(int id)
        {
            Staff output = null;
            for (int i = 0; i < floorCount; i++)
            {
                Staff tmp = floors[i].GetComponent<Floor>().FindStaff(id);
                if (tmp != null)
                {
                    output = tmp;
                    break;
                }
            }
            return output;
        }

        /// <summary>
        /// Looks through entire building to find a researcher
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Staff RemoveStaff(string name)
        {
            Staff output = null;
            for (int i = 0; i < floorCount; i++)
            {
                Staff tmp = floors[i].GetComponent<Floor>().RemoveStaff(name);
                if (tmp != null)
                {
                    output = tmp;
                    break;
                }
            }
            return output;
        }

        public Staff RemoveStaff(int id)
        {
            Staff output = null;
            for (int i = 0; i < floorCount; i++)
            {
                Staff tmp = floors[i].GetComponent<Floor>().RemoveStaff(id);
                if (tmp != null)
                {
                    output = tmp;
                    break;
                }
            }
            return output;
        }
    }
}
