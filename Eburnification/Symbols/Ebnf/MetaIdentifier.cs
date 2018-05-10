// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class MetaIdentifier : Symbol<MetaIdentifier>
    {
        public override SymbolKind Kind => SymbolKind.Identifier;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            if (!char.IsLetter(parser.Peek() ?? '\0'))
                return ParsingResult.None;
            // which is actually always true, since we ask for as many as we wantd
            return tokenizer.ParseSequence(parser, MetaIdentifierCharacter.Instance, int.MaxValue).AsTerminal();
        }
    }
}