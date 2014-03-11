using System;
using mattt.data;

namespace mattt.mapping
{
    public class Mapper
    {
        public GameState Map(Tuple<int, char>[] playerMoves, string status)
        {
            const int DIM = 3;
            var gs = new GameState {Board = new char[DIM,DIM], Status = status};

            foreach (var playerMove in playerMoves)
            {
                var posX = playerMove.Item1 % DIM;
                var posY = playerMove.Item1/DIM;
                gs.Board[posX, posY] = playerMove.Item2;
            }

            return gs;
        }
    }
}
