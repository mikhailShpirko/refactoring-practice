using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private const int _cellSize = 70;

        private readonly GridPresenter _gridPresenter;
        private readonly Grid _grid;
        private readonly PointToCellConverter _pointToCellConverter;
        private readonly CurrentMove _currentMove;
        private readonly GameState _gameState;

        public Form1()
        {
            InitializeComponent();
         
            _grid = new Grid();
            _gridPresenter = new GridPresenter(_grid, _cellSize);
            _pointToCellConverter = new PointToCellConverter(_cellSize);
            _currentMove = new CurrentMove();
            _gameState = new GameState(_grid);
        }


        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            _gridPresenter.Draw(g);
        }

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {

            var cellIndexes = _pointToCellConverter.ConvertClickPointToCell(e.Location);

            if (!_grid.IsCellVacant(cellIndexes.Item1, cellIndexes.Item2))
            {
                return;
            }

            _grid.OccupyCell(cellIndexes.Item1, cellIndexes.Item2, _currentMove);

            //redraw
            pnl.Invalidate();

            _currentMove.SwitchMove();

            //check winner
            if (_gameState.HasWinner(out var winner))
            {
                MessageBox.Show($"Player {(int)winner} wins");
                ResetGame();
            }

            if (_gameState.IsTie())
            {
                MessageBox.Show("It's a tie");
                ResetGame();
            }
        }
      

        private void ResetGame()
        {
            _grid.Reset();
            _currentMove.Reset();
            //redraw
            pnl.Invalidate();
        }
    }
}
