using System;
using System.Threading;
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
            var worker = new Thread(() =>
            {
                // TODO: do something
                _moves.Add(coordinate,
                    // onSuccess
                    rawMoves => _game.Check_for_end_of_game(
                        // moves to calclutae with
                        rawMoves,
                        // onGameOver
                        endOfGameStatus => Determine_game_state(_moves.RawMoves, endOfGameStatus),
                        // onContinueGame
                        () =>
                        {
                            var status = _game.Change_player(_moves.RawMoves);
                            Determine_game_state(_moves.RawMoves, status);
                        },
                        // onUpdateUi
                        (newMoves, text) => UpdateUi(newMoves, text)
                    ),
                    // onError
                    errorStatus => Determine_game_state(_moves.RawMoves, errorStatus));
            });
            
            worker.Start();
            
            // disable ui
            SetActive(false);
        }


        private void Determine_game_state(int[] moves, string status)
        {
            var playerMoves = _game.Add_players_to_moves(moves);
            var gs = _mapper.Map(playerMoves, status);
            OnGameChanged(gs);
        }

        private void UpdateUi(int[] moves, string status)
        {
            _moves.RawMoves = moves;
            var playerMoves = _game.Add_players_to_moves(moves);
            var gs = _mapper.Map(playerMoves, status);
            OnGameChanged(gs);
        }

        public event Action<GameState> OnGameChanged;
        public event Action<bool> SetActive;
    }
}
