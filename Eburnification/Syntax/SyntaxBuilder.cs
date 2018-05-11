// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Parsing;
    using Symbols;

    public class SyntaxBuilder
    {
        /// <summary>
        /// Builds a syntax based on given token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public Symbol Build(Token token)
        {
            var definitions = new Dictionary<string, Symbol>();
            return Build(token, definitions);
        }

        private Symbol Build(Token token, IDictionary<string, Symbol> definitions)
        {
            return Or(BuildTree(token, definitions));
        }

        private IEnumerable<Symbol> BuildTree(Token token, IDictionary<string, Symbol> definitions)
        {
            switch (token.Symbol.Kind)
            {
                case SymbolKind.Neutral:
                    return token.Children.SelectMany(token1 => BuildTree(token1, definitions));
                case SymbolKind.Literal:
                    return GetSymbol(new LiteralSymbol(TrimQuotes(token.Value)));
                case SymbolKind.Identifier:
                    return GetSymbol(new LookupSymbol(token.Value, definitions));
                case SymbolKind.OneOf:
                    return GetSymbol(Or(token.Children.SelectMany(t => BuildTree(t, definitions))));
                case SymbolKind.AllOf:
                    return GetSymbol(And(token.Children.SelectMany(t => BuildTree(t, definitions))));
                case SymbolKind.Repeat:
                    var repeatSymbol = (IRepeatSymbol)token.Symbol;
                    var childToken = repeatSymbol.GetSymbol(token.Children);
                    return GetSymbol(new RepeatSymbol(Build(childToken, definitions)));
                case SymbolKind.Definition:
                    var definitionSymbol = (IDefinitionSymbol)token.Symbol;
                    var identifier = definitionSymbol.GetIdentifier(token.Children);
                    var value = definitionSymbol.GetValue(token.Children);
                    definitions[identifier.Value] = Build(value, definitions);
                    return GetSymbol(new DefinitionSymbol(identifier.Value, Build(value, definitions)));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Symbol Or(IEnumerable<Symbol> symbols)
        {
            var symbolArray = symbols.ToArray();
            if (symbolArray.Length == 1)
                return symbolArray[0];
            return new OrSymbol(symbolArray);
        }

        private static Symbol And(IEnumerable<Symbol> symbols)
        {
            var symbolArray = symbols.ToArray();
            if (symbolArray.Length == 1)
                return symbolArray[0];
            return new AndSymbol(symbolArray);
        }

        private static string TrimQuotes(string s)
        {
            if (s.StartsWith("'") && s.EndsWith("'"))
                return s.Substring(1, s.Length - 2);
            if (s.StartsWith("\"") && s.EndsWith("\""))
                return s.Substring(1, s.Length - 2);
            return s;
        }

        private static IEnumerable<Symbol> GetSymbol(Symbol symbol)
        {
            yield return symbol;
        }
    }
}
