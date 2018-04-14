// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class DecimalDigit : Symbol<DecimalDigit>
    {
        public override bool TryParse(Parser parser)
        {
            return parser.TryRead(char.IsDigit);
        }
    }
}