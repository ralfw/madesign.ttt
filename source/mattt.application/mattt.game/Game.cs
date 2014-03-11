using System;
using System.Linq;
using System.Collections.Generic;

namespace mattt.game
{
    public class Game
    {
        public void Check_for_end_of_game(int[] moves, Action<string> onGameOver, Action onContinueGame)
        {
            if (moves.Count() == 9)
            {
                onGameOver("Finds selber raus.");
            }
            else
            {
                onContinueGame();
            }
        }

        public string Change_player(int[] moves)
        {
            var result = "";
            var player = moves.Count()%2;
            if (player == 0)
            {
                result = "Spieler X ist dran.";
            }
            else
            {
                result = "Spieler O ist dran.";
            }
            return result;
        }

        public Tuple<int,char>[] Add_players_to_moves(int[] moves)
        {
            var result = new List<Tuple<int,char>>();

            for (int i = 0; i < moves.Count(); i++)
            {
                result.Add(Tuple.Create<int, char>(moves[i], i%2==0?'X':'O'));
            }
            return result.ToArray();
        }
    }
}
