// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class DecimalDigit : Symbol<DecimalDigit>
    {
        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(parser.TryRead(char.IsDigit));
        }
    }
}