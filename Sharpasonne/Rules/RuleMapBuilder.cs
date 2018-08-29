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
    public class RuleMapBuilder
    {
        public IImmutableDictionary<Type, RuleMap<IGameAction>> RuleMap { get; }

        /// <param name="addRange"></param>
        /// <inheritdoc cref="RuleMapBuilder"/>
        public RuleMapBuilder()
        {
        }

        private RuleMapBuilder([NotNull] IImmutableDictionary<Type, RuleMap<IGameAction>> ruleMap)
        {
            this.RuleMap = ruleMap;
        }

        public RuleMapBuilder Set<TGameAction>([NotNull] RuleMap<TGameAction> rules) where TGameAction:IGameAction
        {
            return new RuleMapBuilder(
                this.RuleMap.SetItem(typeof(TGameAction), rules)
            );
        }

        public static readonly RuleMapBuilder CoreRulesBuilder =
            new RuleMapBuilder().Set<PlaceTileGameAction>(new RuleMap<IGameAction>());
    }

    public class RuleMap<T> where T : IGameAction
    {
        public IImmutableList<IRule<T>> Rules { get; set; }
    }
}