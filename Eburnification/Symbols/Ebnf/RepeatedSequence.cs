﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class RepeatedSequence : Symbol<RepeatedSequence>
    {
        public override SymbolKind Kind => SymbolKind.AllOf;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, StartRepeatSymbol.Instance, DefinitionsList.Instance, EndRepeatSymbol.Instance);
        }
    }
}