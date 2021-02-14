using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.GameLogic
{
    public class TieValidator: IGameOverValidator
    {
        private readonly IReadOnlyGrid _grid;

        public event Action OnTie;

        public TieValidator(IReadOnlyGrid grid)
        {
            _grid = grid;
        }

        public void Validate()
        {
            if (IsTie())
            {
                OnTie?.Invoke();
            }
        }

        private bool IsTie()
        {
            return !_grid.HasEmptyCell();
        }
    }
}
