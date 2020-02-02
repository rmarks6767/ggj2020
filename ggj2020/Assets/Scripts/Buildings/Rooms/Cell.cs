using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        private SCP cellInhabitant;
        private DangerLevel cellLevel;
        private int index;
        private bool isFilled;
        public GameObject cellBlock;
        public int spot;

        public SCP CellInhabitant
        {
            get { return cellInhabitant; }
            set { cellInhabitant = value; }
        }

        public DangerLevel CellLevel
        {
            get { return cellLevel; }
        }

        public bool IsFilled
        {
            get { return isFilled; }
        }

        public int Index
        {
            get { return index; }
        }

        public Cell(DangerLevel cellLevel, int index, GameObject block, int spt, SCP cellInhabitant = null)
        {
            this.cellLevel = cellLevel;
            this.cellInhabitant = cellInhabitant;
            this.index = index;
            this.cellBlock = block;
            this.spot = spt;
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

        public override string ToString()
        {
            if (isFilled)
            {
                return index + " - A " + cellLevel + " cell containing " + CellInhabitant.ToString();
            }
            return index + " - An empty " + cellLevel + " cell";
        }
    }

}