using Sharpasonne.GameActions;

namespace Sharpasonne.Rules
{
    /// <summary>
    /// Determine if a <see cref="IGameAction"/> may be played.
    /// </summary>
    public interface IRule<in T1> where T1 : IGameAction
    {
        /// <inheritdoc cref="IRule{T2}"/>
        bool Verify(IEngine engine, T1 gameAction);
    }
}
