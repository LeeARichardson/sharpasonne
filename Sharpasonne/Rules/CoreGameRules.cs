using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JetBrains.Annotations;
using Sharpasonne.GameActions;
using Sharpasonne.Rules;

namespace Sharpasonne.Rules
{
    /// <summary>
    /// Builds map of IGameActions to rules that apply to it.
    /// </summary>
    /// <remarks>Exists due to Type System limitations that prevent restricting
    /// the key to match the <see cref="IGameAction"/> in the value.</remarks>
    public class CoreGameRules
    {
        protected IImmutableDictionary<Type, IImmutableList<IRule<IGameAction>>> RuleMap =
            new Dictionary<Type, IImmutableList<IRule<IGameAction>>>
            {
                [typeof(PlaceTileGameAction)] = ImmutableList.Create<IRule<IGameAction>>(
                    new AdjacentFeaturesMatchRule() as IRule<IGameAction>,
                    new HasAdjacentTileRule() as IRule<IGameAction>,
                    new SpaceIsEmptyRule() as IRule<IGameAction>
                )
            }.ToImmutableDictionary();

        public IEnumerable<IRule<TGameAction>> RulesFor<TGameAction>()
            where TGameAction : IGameAction
        {
            return this.RuleMap[typeof(TGameAction)].Select(rule => rule as IRule<TGameAction>);
        }
    }
}