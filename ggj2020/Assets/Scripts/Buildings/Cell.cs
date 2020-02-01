using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        private SCP cellInhabitant;
        private DangerLevel cellLevel;


        /// <summary>
        /// Inhabitant of the cell
        /// </summary>
        public SCP CellInhabitant
        {
            get
            {
                return cellInhabitant;
            }
            set
            {
                cellInhabitant = value;
            }
        }

        public DangerLevel CellLevel
        {
            get
            {
                return cellLevel;
            }
            set
            {
                cellLevel = value;
            }
        }

        public Cell(DangerLevel cellLevel, SCP cellInhabitant = null)
        {
            this.cellLevel = cellLevel;
            this.cellInhabitant = cellInhabitant;
        }

    }

}