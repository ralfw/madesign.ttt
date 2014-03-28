using System;
using System.Linq;
using System.Collections.Generic;

namespace mattt.game
{
    public class Game
    {
        private const int DIMENSION = 3;
        private const int WIN_DIMENSION = 3;
        private const int WINNING_SPACE = DIMENSION - WIN_DIMENSION;

        public void Check_for_end_of_game(int[] moves, Action<string> onGameOver, Action onContinueGame)
        {
            var moveTuple = Add_players_to_moves(moves);
            var x = (from tuple in moveTuple where tuple.Item2 == 'X' select tuple.Item1).OrderBy(item => item).ToList();
            var o = (from tuple in moveTuple where tuple.Item2 == 'O' select tuple.Item1).OrderBy(item => item).ToList();

            if (moves.Count() < 5)
            {
                onContinueGame();
            }
            else
            {
                // check if x has won
                if (CheckForWin(x))
                {
                    onGameOver("X hat gewonnen.");
                }
                // else check if o has won
                else if (CheckForWin(o))
                {
                    onGameOver("O hat gewonnen.");
                }
                // else check for remis
                else if (moves.Count() == 9)
                {
                    onGameOver("Remis.");
                }
                // else continue
                else
                {
                    onContinueGame();
                }
            }

            // check all elemnts in x

            //if (HasWonHorizontaly(x) || HasWonVerticaly(x) || HasWonDiagonaly(x))
            //{
            //    onGameOver("X hat gewonnen.");
            //}
            //else if (HasWonHorizontaly(o) || HasWonVerticaly(o) || HasWonDiagonaly(o))
            //{
            //    onGameOver("O hat gewonnen.");
            //}
            //else if (moves.Count() == 9)
            //{
            //    onGameOver("Remis.");
            //}
            //else
            //{
            //    onContinueGame();
            //}
        }

        private bool HasWonHorizontaly(List<int> movesOfPlayer)
        {
            // 0,1,2 ; 3,4,5 ; 6,7,8
            var c0 = movesOfPlayer.Contains(0);
            var c1 = movesOfPlayer.Contains(1);
            var c2 = movesOfPlayer.Contains(2);
            var c3 = movesOfPlayer.Contains(3);
            var c4 = movesOfPlayer.Contains(4);
            var c5 = movesOfPlayer.Contains(5);
            var c6 = movesOfPlayer.Contains(6);
            var c7 = movesOfPlayer.Contains(7);
            var c8 = movesOfPlayer.Contains(8);
            if (c0 && c1 && c2)
            {
                return true;
            }
            if (c3 && c4 && c5)
            {
                return true;
            }
            if (c6 && c7 && c8)
            {
                return true;
            }
            return false;
        }

        private bool HasWonVerticaly(List<int> movesOfPlayer)
        {
            // 0,3,6 ; 1,4,7 ; 2,5,8
            var c0 = movesOfPlayer.Contains(0);
            var c1 = movesOfPlayer.Contains(1);
            var c2 = movesOfPlayer.Contains(2);
            var c3 = movesOfPlayer.Contains(3);
            var c4 = movesOfPlayer.Contains(4);
            var c5 = movesOfPlayer.Contains(5);
            var c6 = movesOfPlayer.Contains(6);
            var c7 = movesOfPlayer.Contains(7);
            var c8 = movesOfPlayer.Contains(8);
            if (c0 && c3 && c6)
            {
                return true;
            }
            if (c1 && c4 && c7)
            {
                return true;
            }
            if (c2 && c5 && c8)
            {
                return true;
            }
            return false;
        }

        private bool HasWonDiagonaly(List<int> movesOfPlayer)
        {
            // 0,4,8 ; 2,4,6
            var c0 = movesOfPlayer.Contains(0);
            var c2 = movesOfPlayer.Contains(2);
            var c4 = movesOfPlayer.Contains(4);
            var c6 = movesOfPlayer.Contains(6);
            var c8 = movesOfPlayer.Contains(8);
            if (c0 && c4 && c8)
            {
                return true;
            }
            if (c2 && c4 && c6)
            {
                return true;
            }
            return false;
        }

        public string Change_player(int[] moves)
        {
            var result = "";
            var player = moves.Count() % 2;
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

        public Tuple<int, char>[] Add_players_to_moves(int[] moves)
        {
            var result = new List<Tuple<int, char>>();

            for (int i = 0; i < moves.Count(); i++)
            {
                result.Add(Tuple.Create<int, char>(moves[i], i % 2 == 0 ? 'X' : 'O'));
            }
            return result.ToArray();
        }

        private bool CheckForWin(List<int> movesOfPlayer)
        {
            foreach (var move in movesOfPlayer)
            {
                // check vertical win
                if (move < (WIN_DIMENSION + 1) * DIMENSION)
                {
                    // check for further possible win places
                    var foundVerticalWin = true;
                    for (var i = 0; i < (WIN_DIMENSION - 1); i++)
                    {
                        if (!movesOfPlayer.Contains(move + DIMENSION * (i + 1)))
                        {
                            foundVerticalWin = false;
                            break;
                        }
                    }
                    if (foundVerticalWin)
                    {
                        return true;
                    }
                }
                // check horizontal win
                if (move % DIMENSION <= WINNING_SPACE)
                {
                    var foundHorizontalWin = true;
                    for (int i = 0; i < (WIN_DIMENSION - 1); i++)
                    {
                        if (!movesOfPlayer.Contains(move + (i + 1)))
                        {
                            foundHorizontalWin = false;
                            break;
                        }
                    }
                    if (foundHorizontalWin)
                    {
                        return true;
                    }
                }
                // check diagonal win
                var offset = new Offset
                {
                    X = move % DIMENSION,
                    Y = move / DIMENSION
                };

                // check left down
                if (offset.X > WINNING_SPACE && offset.Y <= WINNING_SPACE)
                {
                    var foundDiagonalWin = true;
                    for (int i = 0; i < WIN_DIMENSION - 1; i++)
                    {
                        if (!movesOfPlayer.Contains(move + (DIMENSION - 1) * (i + 1)))
                        {
                            foundDiagonalWin = false;
                            break;
                        }
                    }
                    if (foundDiagonalWin)
                    {
                        return true;
                    }
                }
                // check right down
                if (offset.X <= WINNING_SPACE && offset.Y <= WINNING_SPACE)
                {
                    var foundDiagonalWin = true;
                    for (int i = 0; i < WIN_DIMENSION - 1; i++)
                    {
                        if (!movesOfPlayer.Contains(move + (DIMENSION + 1) * (i + 1)))
                        {
                            foundDiagonalWin = false;
                            break;
                        }
                    }
                    if (foundDiagonalWin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private class Offset
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }


}
