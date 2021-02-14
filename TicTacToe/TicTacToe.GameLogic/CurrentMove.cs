namespace TicTacToe.GameLogic
{
    public class CurrentMove
    {
        private Players _currentMove;

        public CurrentMove()
        {
            Reset();
        }

        public void SwitchMove()
        {
            _currentMove = _currentMove == Players.Player1 ? Players.Player2 : Players.Player1;
        }

        public void Reset()
        {
            _currentMove = Players.Player1;
        }

        public static implicit operator Players(CurrentMove c) => c._currentMove;
    }
}
