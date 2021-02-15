using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.GameLogic
{
    public class WinnerValidator: IGameOverValidator
    {
        private readonly IReadOnlyGrid _grid;

        public event Action<Players> OnWinner;

        public WinnerValidator(IReadOnlyGrid grid)
        {
            _grid = grid;
        }

        public void Validate()
        {
            if (HasWinner(out var winner))
            {
                OnWinner?.Invoke(winner);
            }
        }

        private bool HasWinner(out Players winner)
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

            winner = (Players)winningCellOccupiedBy;

            return winningCellOccupiedBy != CellOccupiedBy.None;
        }
    }
}
