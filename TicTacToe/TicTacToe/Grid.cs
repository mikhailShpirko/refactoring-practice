namespace TicTacToe
{
    public class Grid
    {
        private CellOccupiedBy[,] _cells = new CellOccupiedBy[3, 3];

        public CellOccupiedBy GetCellOccupiedBy(int i, int j)
        {
            return _cells[i, j];
        }

        public bool IsCellVacant(int i, int j)
        {
            return GetCellOccupiedBy(i,j) == CellOccupiedBy.None;
        }

        public void OccupyCell(int i, int j, Players player)
        {
            _cells[i, j] = (CellOccupiedBy)player;
        }

        public bool HasEmptyCell()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (IsCellVacant(i, j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Reset()
        {
            _cells = new CellOccupiedBy[3, 3];
        }
    }
}
