// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class DecimalDigit : Symbol<DecimalDigit>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(char.IsDigit);
        }
    }
}