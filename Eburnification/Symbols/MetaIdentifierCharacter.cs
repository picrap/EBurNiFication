// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class MetaIdentifierCharacter : Symbol<MetaIdentifierCharacter>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(char.IsLetterOrDigit);
        }
    }
}