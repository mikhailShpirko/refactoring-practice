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
            Player2,
            Tie
        }

        private Players[,] _cells = new Players[3,3];
        private Players _currentMove = Players.Player1;

        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawLine(Pens.Black, 70, 1, 70, 210);
            g.DrawLine(Pens.Black, 140, 1, 140, 210);
            g.DrawLine(Pens.Black, 1, 70, 210, 70);
            g.DrawLine(Pens.Black, 1, 140, 210, 140);

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cellCoordinates = new Rectangle(i * 70 + 1, j * 70 + 1, 69, 69);
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

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {
            var isMove = false;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cellCoordinates = new Rectangle(i * 70 + 1, j * 70 + 1, 69, 69);
                    if (cellCoordinates.Contains(e.Location.X, e.Location.Y))
                    {
                        //check that it's not already occupied
                        if (_cells[i, j] == Players.None)
                        {
                            isMove = true;
                            _cells[i, j] = _currentMove;
                        }
                    }
                }
            }

            if (isMove)
            {
                //redraw
                pnl.Invalidate();

                //change the turn
                _currentMove = _currentMove == Players.Player1 ? Players.Player2 : Players.Player1;

                //check winner
                var winner = CheckWinner();

                if (winner == Players.Tie)
                {
                    MessageBox.Show("It's a tie");
                    ResetGame();
                }
                else if (winner == Players.Player1)
                {
                    MessageBox.Show("Player 1 wins");
                    ResetGame();
                }
                else if(winner == Players.Player2) //go on with current game - AI move
                {
                    MessageBox.Show("Player 2 wins");
                    ResetGame();
                }               
            }
        }

        private Players CheckWinner()
        {
            //check verticals
            for (var i = 0; i < 3; i++)
            {
                if (_cells[i, 0] != Players.None && _cells[i, 0] == _cells[i, 1] && _cells[i, 0] == _cells[i, 2])
                {
                    return _cells[i, 0];
                }
            }

            //check horizontals
            for (var i = 0; i < 3; i++)
            {
                if (_cells[0, i] != Players.None && _cells[0, i] == _cells[1, i] && _cells[0, i] == _cells[2, i])
                {
                    return _cells[0, i];
                }
            }

            //check diagonals
            if (_cells[0, 0] != Players.None && _cells[0, 0] == _cells[1, 1] && _cells[0, 0] == _cells[2, 2])
            {
                return _cells[1, 1];
            }

            if (_cells[2, 0] != Players.None && _cells[2, 0] == _cells[1, 1] && _cells[2, 0] == _cells[0, 2])
            {
                return _cells[1, 1];
            }

            //check tie
            var isTie = true;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (_cells[i, j] == Players.None)
                    {
                        isTie = false;
                    }
                }
            }

            if (isTie)
            {
                return Players.Tie;
            }

            //if we are here - no winner yet
            return Players.None;
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
