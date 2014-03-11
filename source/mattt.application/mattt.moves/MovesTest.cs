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
            Assert.That(moves.RawMoves, Is.Empty);
        }

        [Test]
        public void WhenMoveIsAdded_OnSuccessIsCalled()
        {
            var moves = new Moves();
            int[] actualMoves=null;
            Action<int[]> onSuccess = m => actualMoves = m;
            moves.Add(1, onSuccess, null);

            Assert.That(moves.RawMoves, Is.EquivalentTo(actualMoves));
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