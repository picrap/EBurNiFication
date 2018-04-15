// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    /// <summary>
    /// special-sequence (§5.11)
    /// </summary>
    public class SpecialSequence : Symbol<SpecialSequence>
    {
        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            // the ISO defines it for extension, so in this strict use, 
            // we'll never get a special-sequence
            return AnyToken.None;
        }
    }
}