namespace TicTacToe
{
    public class GameState
    {
        private readonly Grid _grid;

        public GameState(Grid grid)
        {
            _grid = grid;
        }

        public bool HasWinner(out Players winner)
        {
            var winningCellOccupiedBy = CellOccupiedBy.None;
            //check verticals
            for (var i = 0; i < 3; i++)
            {
                //vertical
                if (!_grid.IsCellVacant(i, 0) &&
                    _grid.GetCellOccupiedBy(i, 0) == _grid.GetCellOccupiedBy(i, 1) &&
                    _grid.GetCellOccupiedBy(i, 1) == _grid.GetCellOccupiedBy(i, 2))
                {
                    winningCellOccupiedBy = _grid.GetCellOccupiedBy(i, 0);
                }

                //horizontal
                if (!_grid.IsCellVacant(0, i) &&
                    _grid.GetCellOccupiedBy(0, i) == _grid.GetCellOccupiedBy(1, i) &&
                    _grid.GetCellOccupiedBy(0, i) == _grid.GetCellOccupiedBy(2, i))
                {
                    winningCellOccupiedBy = _grid.GetCellOccupiedBy(0, i);
                }
            }


            //check diagonals
            if (!_grid.IsCellVacant(1, 1))
            {
                if (_grid.GetCellOccupiedBy(1, 1) == _grid.GetCellOccupiedBy(0, 0) &&
                    _grid.GetCellOccupiedBy(1, 1) == _grid.GetCellOccupiedBy(2, 2))
                {
                    winningCellOccupiedBy = _grid.GetCellOccupiedBy(1, 1);
                }

                if (_grid.GetCellOccupiedBy(1, 1) == _grid.GetCellOccupiedBy(2, 0) &&
                    _grid.GetCellOccupiedBy(1, 1) == _grid.GetCellOccupiedBy(0, 2))
                {
                    winningCellOccupiedBy = _grid.GetCellOccupiedBy(1, 1);
                }
            }

            winner = (Players) winningCellOccupiedBy;

            return winningCellOccupiedBy != CellOccupiedBy.None;
        }

        public bool IsTie()
        {
            return !_grid.HasEmptyCell();
        }
    }
}
