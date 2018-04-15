// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class Letter : Symbol<Letter>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(parser.TryRead(char.IsLetter));
        }
    }
}