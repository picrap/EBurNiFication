// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class SingleDefinition : Symbol<SingleDefinition>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseSeparated(parser, SyntacticTerm.Instance, ConcatenateSymbol.Instance);
        }
    }
}
