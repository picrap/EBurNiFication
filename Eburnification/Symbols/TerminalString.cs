// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class TerminalString : Symbol<TerminalString>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseQuoteSequence(parser, FirstQuoteSymbol.Instance, FirstTerminalCharacter.Instance, FirstQuoteSymbol.Instance)
                   ?? tokenizer.ParseQuoteSequence(parser, SecondQuoteSymbol.Instance, SecondTerminalCharacter.Instance, SecondQuoteSymbol.Instance);
        }
    }
}