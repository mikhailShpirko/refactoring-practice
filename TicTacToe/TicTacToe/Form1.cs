using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private enum Players
        {
            None,
            Player1,
            Player2
        }

        private Players[,] _cells = new Players[3,3];
        private Players _currentMove = Players.Player1;

        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            DrawGrid(g);
            FillCells(g);
        }

        private void DrawGrid(Graphics g)
        {
            for (var i = 1; i < 3; i++)
            {
                g.DrawLine(Pens.Black, i * 70, 1, i * 70, 210);
                g.DrawLine(Pens.Black, 1, i * 70, 210, i * 70);
            }
        }

        private void FillCells(Graphics g)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cellCoordinates = GetCellCoordinates(i, j);
                    if (_cells[i, j] == Players.Player1)
                    {
                        g.FillRegion(Brushes.Blue, new Region(cellCoordinates));
                    }
                    else if (_cells[i, j] == Players.Player2)
                    {
                        g.FillRegion(Brushes.Red, new Region(cellCoordinates));
                    }
                }
            }
        }

        private Rectangle GetCellCoordinates(int i, int j)
        {
            return new Rectangle(i * 70 + 1, j * 70 + 1, 69, 69);
        }

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {
            if (TryMakeMove(e.Location))
            {
                //redraw
                pnl.Invalidate();

                //change the turn
                _currentMove = _currentMove == Players.Player1 ? Players.Player2 : Players.Player1;

                //check winner
                if (HasWinner(out var winner))
                {
                    MessageBox.Show($"Player {(int)winner} wins");
                    ResetGame();
                }

                if (!HasEmptyCell())
                {
                    MessageBox.Show("It's a tie");
                    ResetGame();
                }
            }
        }

        private bool TryMakeMove(Point clickCoordinates)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cellCoordinates = GetCellCoordinates(i, j);
                    if (cellCoordinates.Contains(clickCoordinates.X, clickCoordinates.Y))
                    {
                        //check that it's not already occupied
                        if (_cells[i, j] == Players.None)
                        {                            
                            _cells[i, j] = _currentMove;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool HasWinner(out Players winner)
        {
            winner = Players.None;
            //check verticals
            for (var i = 0; i < 3; i++)
            {
                //vertical
                if (_cells[i, 0] != Players.None && _cells[i, 0] == _cells[i, 1] && _cells[i, 0] == _cells[i, 2])
                {
                    winner = _cells[i, 0];
                }

                //horizontal
                if (_cells[0, i] != Players.None && _cells[0, i] == _cells[1, i] && _cells[0, i] == _cells[2, i])
                {
                    winner = _cells[0, i];
                }
            }


            //check diagonals
            if (_cells[0, 0] != Players.None && _cells[0, 0] == _cells[1, 1] && _cells[0, 0] == _cells[2, 2])
            {
                winner = _cells[1, 1];
            }

            if (_cells[2, 0] != Players.None && _cells[2, 0] == _cells[1, 1] && _cells[2, 0] == _cells[0, 2])
            {
                winner = _cells[1, 1];
            }

            return winner != Players.None;

        }

        private bool HasEmptyCell()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (_cells[i, j] == Players.None)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void ResetGame()
        {
            //clear the cells
            _cells = new Players[3,3];

            _currentMove = Players.Player1;
            //redraw
            pnl.Invalidate();
        }
    }
}
