using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class ResearchRoom : Room
    {
        private int maxStaff;
        private int roomTier;
        private int maxRoomTier;
        private int incrementingValue;

        /// <summary>
        /// Current level of the room
        /// </summary>
        public int RoomTier
        {
            get { return roomTier; }
        }


        /// <summary>
        /// Current count of the staff
        /// </summary>
        public int StaffCount
        {
            get { return residentResearchers.Count; }
        }

        private List<Researcher> residentResearchers;

        private BuildingType building;

        public ResearchRoom(BuildingType building)  
        {
            this.building = building;

            maxRoomTier = 3;
            incrementingValue = 2;

            residentResearchers = new List<Researcher>();

            maxStaff = 2;
            roomTier = 0;
        }

        /// <summary>
        /// If the staff adding is invalid will return false
        /// </summary>
        /// <returns></returns>
        public bool AddStaff(Researcher newStaff)
        {
            if (maxStaff == (residentResearchers.Count))
            {
                return false;
            }

            residentResearchers.Add(newStaff);
            return true;
        }

        /// <summary>
        /// Will return null if staff name doesnt exist on floor
        /// </summary>
        /// <param name="removeName"></param>
        /// <returns></returns>
        public Researcher RemoveStaff(string removeName)
        {
            Researcher staffStorage;

            for (int i = 0; i < residentResearchers.Count; i++)
            {
                if (removeName == residentResearchers[i].name)
                {
                    staffStorage = residentResearchers[i];
                    residentResearchers.RemoveAt(i);
                    return staffStorage;
                }
            }

            return null;
        }

        /// <summary>
        /// Will return null if staff name doesnt exist on floor
        /// </summary>
        /// <param name="removeName"></param>
        /// <returns></returns>
        public Researcher FindStaff(string removeName)
        {
            Researcher staffStorage;

            for (int i = 0; i < residentResearchers.Count; i++)
            {
                if (removeName == residentResearchers[i].name)
                {
                    staffStorage = residentResearchers[i];
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
            if (roomTier == maxRoomTier)
            {
                return false;
            }

            roomTier++;
            maxStaff += incrementingValue;
            return true;
        }


    }
}
