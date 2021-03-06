﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Staff : MonoBehaviour
    {


        public int tier;
        public string staffName;
        public string description;
        public StaffType type;
        public int iD;
        public CoreAI aiController;
        public GameObject currentLocation;

        public GameObject CurrentLocation
        {
            get { return currentLocation; }
            set { currentLocation = value; }
        }

        private void Start()
        {
            aiController = gameObject.GetComponent<CoreAI>();
            tier = 1;
        }
        public override string ToString()
        {
            return staffName + ", " + " Level: " + tier + ", " + description + ", " + type + ", " + iD;
        }
        
        public void AssignData(string name, int ID)
        {
            staffName = name;
            iD = ID;
        }

        public void AssignLocation(GameObject roomToMoveTo)
        {
            this.aiController.LeaveRoom(roomToMoveTo);
        }
        public void AssignRole(StaffType staffType)
        {
            type = staffType;
        }
    }
}
