// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class TerminalString : Symbol<TerminalString>
    {
        public override bool IsCommentlessSymbol => true;

        public override SymbolKind Kind => SymbolKind.Literal;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            var parsingResult = tokenizer.ParseQuoteSequence(parser, FirstQuoteSymbol.Instance, FirstTerminalCharacter.Instance, FirstQuoteSymbol.Instance)
                   ^ (() => tokenizer.ParseQuoteSequence(parser, SecondQuoteSymbol.Instance, SecondTerminalCharacter.Instance, SecondQuoteSymbol.Instance));
            return parsingResult.AsTerminal();
        }
    }
}