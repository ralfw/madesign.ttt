using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mattt.data
{
    public class GameState
    {
        public char[,] Board; // 3x3, X or O or blank 
        public string Status; // message for UI
    }
}
