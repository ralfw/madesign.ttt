using System;
using matt.contract;
using mattt.data;

namespace mattt.mapping
{
    public class Mapper
    {
        public GameState Map(Tuple<int, char>[] playerMoves, string status)
        {
            var gs = new GameState { Board = new char[Configuration.Instance.Dimension, Configuration.Instance.Dimension], Status = status };

            foreach (var playerMove in playerMoves)
            {
                var posX = playerMove.Item1 % Configuration.Instance.Dimension;
                var posY = playerMove.Item1 / Configuration.Instance.Dimension;
                gs.Board[posX, posY] = playerMove.Item2;
            }

            return gs;
        }
    }
}
