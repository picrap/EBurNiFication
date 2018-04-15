﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class FirstTerminalCharacter : Symbol<FirstTerminalCharacter>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(c => c != '\'') ? NoToken() : null;
        }
    }
}
