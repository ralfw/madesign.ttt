using System;
using NUnit.Framework;

namespace mattt.moves
{
    [TestFixture]
    public class MovesTest
    {
        [Test]
        public void WhenMovesAreCreated_AllMoves_ShallBeEmpty()
        {
            var moves = new Moves();
            Assert.That( moves.RawMoves, Is.Empty );
        }

        [Test]
        public void WhenMoveIsAdded_OnSuccess_IsCalled()
        {
            var moves = new Moves();
            int[] actualMoves=null;
            Action<int[]> onSuccess = m => actualMoves = m;
            moves.Add( 1, onSuccess, null );

            Assert.That( moves.RawMoves, Is.EquivalentTo( new[] { 1 } ) );
        }

        [Test]
        public void WhenMoveIsAlreadyKnown_Then_OnError_IsCalled()
        {
            var moves = new Moves();
            Action<int[]> onSuccess = m => {};

            string actualMsg=null;
            Action<string> onError = msg => actualMsg = msg;

            moves.Add( 1, onSuccess, onError );
            Assert.That( moves.RawMoves, Is.EquivalentTo( new[] { 1 } ) );
            Assert.That( actualMsg, Is.Null );

            moves.Add( 1, onSuccess, onError );
            Assert.That( moves.RawMoves, Is.EquivalentTo( new[] { 1 } ) );
            Assert.That( actualMsg, Is.EquivalentTo( "Koordinate 1 nicht erlaubt." ) );
        }


        [Test]
        public void Reset_WillClearMoves()
        {
            var moves = new Moves();
            int[] actualMoves=null;
            Action<int[]> onSuccess = m => actualMoves = m;
            moves.Add( 1, onSuccess, null );

            moves.Reset();
            Assert.That( moves.RawMoves, Is.Empty );
        }
    }
}