using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mattt.data;
using mattt.game;
using mattt.mapping;
using mattt.moves;

namespace mattt.application
{
    class Interactions
    {
        private readonly Moves _moves;
        private readonly Game _game;
        private readonly Mapper _mapper;

        public Interactions(Moves moves, Game game, Mapper mapper)
        {
            _moves = moves;
            _game = game;
            _mapper = mapper;
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
            _moves.Add(coordinate,
                rawMoves =>
                _game.Check_for_end_of_game(rawMoves,
                    status => Determine_game_state(_moves.RawMoves, status),
                    () => {
                        var status = _game.Change_player(_moves.RawMoves);
                        Determine_game_state(_moves.RawMoves, status);
                    }),
                errorStatus => Determine_game_state(_moves.RawMoves, errorStatus));
        }


        private void Determine_game_state(int[] moves, string status)
        {
            var playerMoves = _game.Add_players_to_moves(moves);
            var gs = _mapper.Map(playerMoves, status);
            OnGameChanged(gs);
        }


        public event Action<GameState> OnGameChanged;
    }
}
