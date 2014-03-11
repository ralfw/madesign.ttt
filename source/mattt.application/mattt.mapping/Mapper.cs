using System;
using mattt.data;

namespace mattt.mapping
{
    public class Mapper
    {
        public GameState Map(Tuple<int, char>[] playerMoves, string status)
        {
           return new GameState{Board=new char[3,3], Status = string.Empty};
        }
    }
}
