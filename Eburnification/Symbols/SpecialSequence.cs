// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    /// <summary>
    ///     special-sequence (§5.11)
    /// </summary>
    public class SpecialSequence : Symbol<SpecialSequence>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            // the ISO defines it for extension, so in this strict use, 
            // we'll never get a special-sequence
            return ParsingResult.None;
        }
    }
}