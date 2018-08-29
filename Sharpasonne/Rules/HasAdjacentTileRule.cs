using Sharpasonne.GameActions;
using System.Linq;

namespace Sharpasonne.Rules
{
    /// <summary>
    /// Verify that the <see cref="PlaceTileGameAction"/> will place a tile
    /// adjacent to a pre-existing tile.
    /// </summary>
    public class HasAdjacentTileRule : IRule<PlaceTileGameAction>
    {
        public bool Verify(IEngine engine, PlaceTileGameAction gameAction)
        {
            var isValid = !engine.Board.ToImmutableDictionary().Any()
                || engine.Board.GetAdjecentTiles(gameAction.Point)
                    .Values
                    .Any(optionalTile => optionalTile.HasValue);

            return isValid;
        }
    }
}
