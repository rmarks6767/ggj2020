namespace Assets.Scripts
{

    public class CellBlock : Room
    {
        private BuildingType building;
        private Cell[] cells;
        private int maxCells;

        public int MaxCells
        {
            get
            {
                return maxCells;
            }
        }

        public Cell[] Cells
        {
            get
            {
                return cells[];
            }
        }

        public CellBlock(BuildingType building)
        {
            this.building = building;
            maxCells = 3;
            cells = new Cell[maxCells];

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell(DangerLevel.safe);
            }
        }
    }
}
