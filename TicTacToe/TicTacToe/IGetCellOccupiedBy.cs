using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IGetCellOccupiedBy
    {
        CellOccupiedBy GetCellOccupiedBy(int i, int j);
    }
}
