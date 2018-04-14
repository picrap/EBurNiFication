// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class GapSeparator : Symbol<GapSeparator>
    {
        public override bool TryParse(Parser parser)
        {
            while (parser.TryRead(" ") || parser.TryRead("\t") || parser.TryRead("\n")
                   || parser.TryRead("\r\n") || parser.TryRead("\r"))
            {
            }

            return true;
        }
    }
}