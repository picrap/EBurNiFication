// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class OptionalSequence : Symbol<OptionalSequence>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, StartOptionSymbol.Instance, DefinitionsList.Instance, EndOptionSymbol.Instance);
        }
    }
}