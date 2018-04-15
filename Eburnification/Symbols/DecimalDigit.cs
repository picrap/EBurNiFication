// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class DecimalDigit : Symbol<DecimalDigit>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(char.IsDigit) ? NoToken() : null;
        }
    }
}
