using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameLogic
{
    public interface IGetCellOccupiedBy
    {
        CellOccupiedBy GetCellOccupiedBy(int i, int j);
    }
}
