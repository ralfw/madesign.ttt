using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mattt.data;
using mattt.game;
using mattt.moves;

namespace mattt.application
{
    class Interactions
    {
        private readonly Moves _moves;
        private readonly Game _game;

        public Interactions(Moves moves, Game game)
        {
            _moves = moves;
            _game = game;
        }


        public void Start()
        {
            New_game();
        }


        public void New_game()
        {
            _moves.Reset();
            var status = _game.Change_player(_moves.RawMoves);
            Determine_game_state(_moves.RawMoves, status);
        }


        public void Move(int coordinate)
        {
            
        }


        private void Determine_game_state(int[] moves, string status)
        {
            
        }


        public event Action<Tuple<int,char>[],string> OnGameChanged;
    }
}
