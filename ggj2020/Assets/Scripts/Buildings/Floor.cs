using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Floor : MonoBehaviour
    {
        protected BuildingType buildingType;
        protected int floorNumber, maxStaff, currentRoomTier, maxRoomTier;
        public List<GameObject> residentStaff;

        /// <summary>
        /// Current level of the room
        /// </summary>
        public int CurrentRoomTier
        {
            get { return currentRoomTier; }
        }


        /// <summary>
        /// Current count of the staff
        /// </summary>
        public int StaffCount
        {
            get { return residentStaff.Count; }
        }

        /// <summary>
        /// Current number of the floor
        /// </summary>
        public int FloorNumber
        {
            get { return floorNumber; }
        }

        /// <summary>
        /// Type of this floor's building
        /// </summary>
        public BuildingType Type
        {
            get { return buildingType; }
        }

        public bool IsFilled
        {
            get { return residentStaff.Count >= maxStaff; }
        }

        public virtual void Start()
        {
            residentStaff = new List<GameObject>();
        }


        /// <summary>
        /// Will return null if staff name doesnt exist on floor
        /// </summary>
        /// <param name = "removeName" ></ param >
        /// < returns ></ returns >
        public Staff RemoveStaff(int id)
        {
            Staff staffStorage;

            for (int i = 0; i < residentStaff.Count; i++)
            {
                if (id == residentStaff[i].GetComponent<Staff>().iD)
                {
                    staffStorage = residentStaff[i].GetComponent<Staff>();
                    residentStaff.RemoveAt(i);
                    return staffStorage;
                }
            }

            return null;
        }

        public Staff RemoveStaff(string name)
        {
            Staff staffStorage;

            for (int i = 0; i < residentStaff.Count; i++)
            {
                if (name == residentStaff[i].GetComponent<Staff>().staffName)
                {
                    staffStorage = residentStaff[i].GetComponent<Staff>();
                    residentStaff.RemoveAt(i);
                    return staffStorage;
                }
            }

            return null;
        }

        /// <summary>
        /// Will return null if staff name doesnt exist on floor
        /// </summary>
        /// <param name = "removeName" ></ param >
        /// < returns ></ returns >
        public Staff FindStaff(int id)
        {
            Staff staffStorage;

            for (int i = 0; i < residentStaff.Count; i++)
            {
                if (id == residentStaff[i].GetComponent<Staff>().iD)
                {
                    staffStorage = residentStaff[i].GetComponent<Staff>();
                    return staffStorage;
                }
            }

            return null;
        }

        public Staff FindStaff(string name)
        {
            Staff staffStorage;

            for (int i = 0; i < residentStaff.Count; i++)
            {
                if (name == residentStaff[i].GetComponent<Staff>().staffName)
                {
                    staffStorage = residentStaff[i].GetComponent<Staff>();
                    return staffStorage;
                }
            }

            return null;
        }

        /// <summary>
        /// If the upgrade is invalid will return false
        /// </summary>
        /// <returns></returns>
        public bool RoomUpgrade()
        {
            if (currentRoomTier == maxRoomTier)
            {
                return false;
            }

            currentRoomTier++;
            maxStaff++;
            return true;
        }

        public override string ToString()
        {
            return $"Floor number: {floorNumber}, Building Type: {buildingType}";
        }
    }
}
