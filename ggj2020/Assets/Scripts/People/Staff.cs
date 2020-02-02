using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Staff : MonoBehaviour
    {
        private int tier;
        private string staffName;
        private string description;
        private StaffType type;

        // A Unique ID for each person
        private int iD;

        public int Tier
        {
            get { return tier; }
            set { tier = value; }
        }

        public string StaffName
        {
            get { return StaffName; }
            set { StaffName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public StaffType Type
        {
            get { return type; }
            set { type = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }


        public Staff(int tier, int iD, string staffName, StaffType type, string description)
        {
            this.tier = tier;
            this.iD = iD;
            this.staffName = staffName;
            this.description = description;
        }

        public override string ToString()
        {
            return staffName + ", " + " Level: " + tier + ", " + description;
        }

    }
}
