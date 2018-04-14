// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class SecondTerminalCharacter : Symbol
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(c => c != '\"');
        }
    }
}