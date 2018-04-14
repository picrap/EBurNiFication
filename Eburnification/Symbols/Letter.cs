﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class Letter : Symbol<Letter>
    {
        public override bool TryParse(Parser parser)
        {
            return parser.TryRead(char.IsLetter);
        }
    }
}