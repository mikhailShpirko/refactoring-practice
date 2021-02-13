using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GridPresenter
    {

        private readonly Dictionary<CellOccupiedBy, Brush> _cellOccupiedColor = new Dictionary<CellOccupiedBy, Brush>
        {
            { CellOccupiedBy.None, Brushes.Transparent },
            { CellOccupiedBy.Player1, Brushes.Blue},
            { CellOccupiedBy.Player2,Brushes.Red }
        };

        private readonly Grid _grid;
        private readonly int _cellSize;

        public GridPresenter(Grid grid, int cellSize)
        {
            _grid = grid;
            _cellSize = cellSize;
        }

        public void Draw(Graphics g)
        {
            DrawGrid(g);
            FillCells(g);
        }

        private void DrawGrid(Graphics g)
        {
            for (var i = 1; i < 3; i++)
            {
                g.DrawLine(Pens.Black, i * _cellSize, 1, i * _cellSize, _cellSize * 3);
                g.DrawLine(Pens.Black, 1, i * _cellSize, _cellSize * 3, i * _cellSize);
            }
        }

        private void FillCells(Graphics g)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cellOccupiedBy = _grid.GetCellOccupiedBy(i, j);
                    if(_cellOccupiedColor.TryGetValue(cellOccupiedBy, out var cellColor))
                    {
                        g.FillRegion(cellColor, new Region(GetCellCoordinates(i,j)));
                    }
                }
            }
        }

        private Rectangle GetCellCoordinates(int i, int j)
        {
            return new Rectangle(i * _cellSize + 1, j * _cellSize + 1, _cellSize - 1, _cellSize - 1);
        }
    }
}
