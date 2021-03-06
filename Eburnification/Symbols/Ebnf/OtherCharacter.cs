﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using System.Collections.Generic;
    using System.Linq;
    using Parsing;

    public class OtherCharacter : Symbol<OtherCharacter>
    {
        private static readonly IEnumerable<char> OtherCharacters = new char[] { ' ', '.', ':', '!', '+', '_', '%', '@', '&', '#', '$', '<', '>', '/', '\\', '~', '^' };

        public override SymbolKind Kind => SymbolKind.Literal;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(c => OtherCharacters.Contains(c));
        }
    }
}