using System;

namespace TicTacToe.GameLogic
{
    public class GameState
    {
        private readonly IGameOverValidator[] _validators;
        
        public GameState(IGameOverValidator[] validators)
        {
            _validators = validators;
        }

        public void ValidateGameOver()
        {
            foreach (var validator in _validators)
            {
                validator.Validate();
            }
            
            
        }
    }
}
