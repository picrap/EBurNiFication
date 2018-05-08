// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    /// <summary>
    ///     gap-separator (§6.4)
    /// </summary>
    public class GapSeparator : Symbol<GapSeparator>
    {
        public override bool IsSignificant => false;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            while (parser.TryRead(" ") || parser.TryRead("\t") || parser.TryRead("\n")
                   || parser.TryRead("\r\n") || parser.TryRead("\r"))
            {
            }

            return true;
        }
    }
}