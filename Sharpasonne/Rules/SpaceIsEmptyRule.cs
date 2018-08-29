using Sharpasonne.GameActions;

namespace Sharpasonne.Rules
{
    /// <summary>
    /// Verify that the there is not already a tile at that location.
    /// </summary>
    public class SpaceIsEmptyRule : IRule<PlaceTileGameAction>
    {
        public bool Verify(IEngine engine, PlaceTileGameAction gameAction)
        {
            var optionalTile = engine.Board.Get(gameAction.Point);

            return !optionalTile.HasValue;
        }
    }
}
