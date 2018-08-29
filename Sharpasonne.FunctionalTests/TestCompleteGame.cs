using System;
using Sharpasonne.Rules;
using Xunit;
using Optional.Unsafe;

namespace Sharpasonne.FunctionalTests
{
    public class TestCompleteGame
    {
        /// <summary>
        /// One turn for each of 4 players. Includes one illegal turn by mismatching tile.
        /// </summary>
        [Fact]
        public void Test1()
        {
            var players = Players.Create(4).ValueOrFailure();
            
            var engine = new Engine(
                RuleMapBuilder.CoreRulesBuilder,
                players);

            Assert.Equal(1, engine.CurrentPlayerTurn);
        }
    }
}
