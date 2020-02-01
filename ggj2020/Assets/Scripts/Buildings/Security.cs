using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Security : Buildings
    {
        // Max ammount of floors possible in the building 
        private int maxFloors;
        private int numberOfFloors;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFloors">Max floors per building</param>
        /// <param name="maxCells">Max cells per floor</param>
        public Security(int maxFloors = 5)
        {
            this.maxFloors = maxFloors;

        }

        public override void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public override void Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}
