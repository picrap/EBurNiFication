// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class Integer : Symbol<Integer>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseSequence(parser, DecimalDigit.Instance, 1, int.MaxValue);
        }
    }
}