using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{

    public class Containment : Buildings
    {

        private int maxFloors;
        private int maxCells;

        /// <summary>
        /// [Floor #, Cell #]
        /// </summary>
        private Cell[,] containmentFloors; 
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFloors">Max floors per building</param>
        /// <param name="maxCells">Max cells per floor</param>
        public Containment(int maxFloors = 3, int maxCells = 6)
        {
            this.maxFloors = maxFloors;
            this.maxCells = maxCells;
            containmentFloors = new Cell[maxFloors, maxCells];
        }

        /// <summary>
        /// Adds an SCP to an aviliable 
        /// </summary>
        public void AddSCP()
        {

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
