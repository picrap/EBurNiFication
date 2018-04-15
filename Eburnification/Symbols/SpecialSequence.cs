// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class SpecialSequence : Symbol<SpecialSequence>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            // the ISO defines it for extension, so in this strict use, 
            // we'll never get a special-sequence
            return null;
        }
    }
}