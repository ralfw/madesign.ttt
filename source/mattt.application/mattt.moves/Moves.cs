using System;
using System.Collections.Generic;
using System.Linq;

namespace mattt.moves
{
    public class Moves
    {
        private List<int> _moves = new List<int>();

        public void Add( int coordinate, Action<int[]> onSuccess, Action<string> onError )
        {
            //if ( coordinate < 0 || coordinate > 8 )
            //    throw new ArgumentException("Coordinate must be 0..8, but was " + coordinate.ToString());
           
            if ( _moves.Any( c => c == coordinate ) )
            {
                onError( string.Format( "Koordinate {0} nicht erlaubt.", coordinate ) );
            }
            else
            {
                _moves.Add( coordinate );
                onSuccess( RawMoves );
            }
        }


        public void Reset()
        {
            _moves.Clear();
        }


        public int[] RawMoves
        {
            get { return _moves.ToArray(); }
            set { _moves = value.ToList(); }
        }
    }
}
