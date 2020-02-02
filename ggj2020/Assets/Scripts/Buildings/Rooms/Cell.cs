using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        private SCP cellInhabitant;
        private DangerLevel cellLevel;
        private bool isFilled;

        public SCP CellInhabitant
        {
            get { return cellInhabitant; }
        }

        public DangerLevel CellLevel
        {
            get { return cellLevel; }
        }

        public bool IsFilled
        {
            get { return IsFilled; }
        }

        public Cell(DangerLevel cellLevel, SCP cellInhabitant = null)
        {
            this.cellLevel = cellLevel;
            this.cellInhabitant = cellInhabitant;

            isFilled = false;
        }

        /// <summary>
        /// Adds an SCP to the Cell
        /// </summary>
        /// <param name="scip">the SCP to be placed in the Cell</param>
        public void ContainSCP(SCP scip)
        {
            cellInhabitant = scip;
            isFilled = true;
        }


    }

}