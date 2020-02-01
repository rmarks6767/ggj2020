using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class Researcher : MonoBehaviour
    {
        private int tier;
        private string staffName;
        private string description;

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

        public Researcher(int tier, string staffName, string description)
        {
            this.tier = tier;
            this.staffName = staffName;
            this.description = description;
        }

        public override string ToString()
        {
            return staffName + ", " + " Level: " + tier + ", " + description;
        }

    }

}
