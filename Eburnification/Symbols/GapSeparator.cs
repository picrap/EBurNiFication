// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class GapSeparator : Symbol<GapSeparator>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            while (tokenizer.TryRead(" ") || tokenizer.TryRead("\t") || tokenizer.TryRead("\n")
                   || tokenizer.TryRead("\r\n") || tokenizer.TryRead("\r"))
            {
            }

            return true;
        }
    }
}