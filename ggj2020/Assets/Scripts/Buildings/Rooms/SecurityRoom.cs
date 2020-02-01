using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public class SecurityRoom : Room
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
            get { return residentGuards.Count; }
        }


        private List<SecurityGuard> residentGuards;

        private BuildingType building;

        public SecurityRoom(BuildingType building)
        {
            this.building = building;

            maxRoomTier = 3;
            incrementingValue = 2;

            residentGuards = new List<SecurityGuard>();

            maxStaff = 2;
            roomTier = 0;
        }

        /// <summary>
        /// If the staff adding is invalid will return false
        /// </summary>
        /// <returns></returns>
        public bool AddStaff(SecurityGuard newStaff)
        {
            if (maxStaff == (residentGuards.Count))
            {
                return false;
            }

            residentGuards.Add(newStaff);
            return true;
        }

        /// <summary>
        /// Will return null if staff name doesnt exist on floor
        /// </summary>
        /// <param name="removeName"></param>
        /// <returns></returns>
        public SecurityGuard RemoveStaff(string removeName)
        {
            SecurityGuard staffStorage;

            for (int i = 0; i < residentGuards.Count; i++)
            {
                if (removeName == residentGuards[i].name)
                {
                    staffStorage = residentGuards[i];
                    residentGuards.RemoveAt(i);
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
        public SecurityGuard FindStaff(string removeName)
        {
            SecurityGuard staffStorage;

            for (int i = 0; i < residentGuards.Count; i++)
            {
                if (removeName == residentGuards[i].name)
                {
                    staffStorage = residentGuards[i];
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