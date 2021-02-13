using System;
using System.Drawing;

namespace TicTacToe
{
    public class PointToCellConverter
    {
        private readonly int _cellSize;

        public PointToCellConverter(int cellSize)
        {
            _cellSize = cellSize;
        }

        public Tuple<int, int> ConvertClickPointToCell(Point clickCoordinates)
        {
            return new Tuple<int, int>(clickCoordinates.X / _cellSize, clickCoordinates.Y / _cellSize);
        }
    }
}
