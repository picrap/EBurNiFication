// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class Integer : Symbol<Integer>
    {
        public override bool TryParse(Parser parser)
        {
            return TryParseSequence(parser, DecimalDigit.Instance, 1, int.MaxValue).HasValue;
        }
    }
}