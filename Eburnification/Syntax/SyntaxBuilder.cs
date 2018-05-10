// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Parsing;
    using Symbols;
    using Symbols.Ebnf;

    public class SyntaxBuilder
    {
        /// <summary>
        /// Builds a syntax based on given token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Symbol Build(Token token)
        {
            return new OrSymbol(BuildTree(token));
        }

        private IEnumerable<Symbol> BuildTree(Token token)
        {
            switch (token.Symbol.Kind)
            {
                case SymbolKind.Neutral:
                    return token.Children.SelectMany(BuildTree);
                case SymbolKind.Literal:
                    return GetSymbol(new LiteralSymbol(TrimQuotes(token.Value), SymbolKind.Literal));
                case SymbolKind.Identifier:
                    return GetSymbol(new LiteralSymbol(token.Value, SymbolKind.Identifier));
                case SymbolKind.OneOf:
                    return GetSymbol(new OrSymbol(token.Children.SelectMany(BuildTree)));
                case SymbolKind.AllOf:
                    return GetSymbol(new AndSymbol(token.Children.SelectMany(BuildTree)));
                case SymbolKind.Definition:
                    var identifier = token.Children.Single(t => t.Symbol.Kind == SymbolKind.Identifier);
                    var value = token.Children.Single(t => t.Symbol.Kind != SymbolKind.Neutral && t.Symbol.Kind != SymbolKind.Identifier);
                    return GetSymbol(new DefinitionSymbol(Build(identifier), Build(value)));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string TrimQuotes(string s)
        {
            if (s.StartsWith("'") && s.EndsWith("'"))
                return s.Substring(1, s.Length - 2);
            if (s.StartsWith("\"") && s.EndsWith("\""))
                return s.Substring(1, s.Length - 2);
            return s;
        }

        private IEnumerable<Symbol> GetSymbol(Symbol symbol)
        {
            yield return symbol;
        }
    }
}
