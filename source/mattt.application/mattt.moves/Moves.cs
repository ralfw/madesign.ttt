using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mattt.moves
{
    public class Moves
    {
        private List<int> _moves = new List<int>();

        public void Add( int coordinate, Action<int[]> onSuccess, Action<string> onError )
        {
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


        public int[] RawMoves { get { return _moves.ToArray(); } }
    }
}
