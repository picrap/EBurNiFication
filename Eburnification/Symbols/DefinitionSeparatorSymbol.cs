﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class DefinitionSeparatorSymbol : Symbol<DefinitionSeparatorSymbol>
    {
        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(parser.TryRead('|') || parser.TryRead('/') || parser.TryRead('!'));
        }
    }
}