using System;
using mattt.data;

namespace mattt.mapping
{
    public class Mapper
    {
        private GameState _gameState;
        private readonly string _status = string.Empty;
        private const int DIM = 3;

        public Mapper()
        {
            Reset();
        }

        public GameState Map(Tuple<int, char>[] playerMoves, string status)
        {
            foreach (var playerMove in playerMoves)
            {
                var posX = playerMove.Item1 % DIM;
                int posY;
                Math.DivRem(playerMove.Item1, DIM, out posY);
                _gameState.Board[posX, posY] = playerMove.Item2;
            }
            _gameState.Status = status;
            return _gameState;
        }

        private void Reset()
        {
            _gameState = new GameState { Board = new char[DIM, DIM], Status = _status };
        }
    }
}
