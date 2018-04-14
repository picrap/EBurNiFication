// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class Integer : Symbol<Integer>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return TryParseSequence(tokenizer, DecimalDigit.Instance, 1, int.MaxValue).HasValue;
        }
    }
}