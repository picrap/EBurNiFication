﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class DefinitionSeparatorSymbol : Symbol<DefinitionSeparatorSymbol>
    {
        public override bool IsGapFreeSymbol => true;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead('|') || parser.TryRead('/') || parser.TryRead('!');
        }
    }
}