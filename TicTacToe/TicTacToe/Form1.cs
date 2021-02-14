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

            _grid.OnCellOccupied += pnl.Invalidate;
            _grid.OnCellOccupied += _currentMove.SwitchMove;
            _grid.OnCellOccupied += _gameState.ValidateGameOver;

            _gameState.OnWinner += ShowWinnerMessage;
            _gameState.OnWinner += _ => ResetGame();
            _gameState.OnTie += ShowTieMessage;
            _gameState.OnTie += ResetGame;
        }


        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            _gridPresenter.Draw(g);
        }

        private void pnl_MouseClick(object sender, MouseEventArgs e)
        {

            var cellIndexes = _pointToCellConverter.ConvertClickPointToCell(e.Location);

            _grid.TryOccupyCell(cellIndexes.Item1, cellIndexes.Item2, _currentMove);

        }

        private void ShowWinnerMessage(Players winner)
        {
            MessageBox.Show($"Player {(int)winner} wins");
        }

        private void ShowTieMessage()
        {
            MessageBox.Show("It's a tie");
        }

        private void ResetGame()
        {
            _grid.Reset();
            _currentMove.Reset();
            //redraw
            pnl.Invalidate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _grid.OnCellOccupied -= pnl.Invalidate;
            _grid.OnCellOccupied -= _currentMove.SwitchMove;
            _grid.OnCellOccupied -= _gameState.ValidateGameOver;
            _gameState.OnWinner -= ShowWinnerMessage;
            _gameState.OnWinner -= _ => ResetGame();
            _gameState.OnTie -= ShowTieMessage;
            _gameState.OnTie -= ResetGame;
        }
    }
}
