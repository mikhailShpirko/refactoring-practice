using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameLogic
{
    public interface IReadOnlyGrid: IGetCellOccupiedBy
    {
        bool IsCellVacant(int i, int j);
        bool HasEmptyCell();
    }
}
