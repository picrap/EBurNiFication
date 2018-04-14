// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class MetaIdentifier : Symbol<MetaIdentifier>
    {
        private readonly MetaIdentifierCharacter _metaIdentifierCharacter = new MetaIdentifierCharacter();

        public override bool TryParse(Tokenizer tokenizer)
        {
            if (!tokenizer.TryRead(char.IsLetter))
                return false;
            // which is actually always true, since we ask for as many as we wantd
            return TryParseSequence(tokenizer, _metaIdentifierCharacter, 0, int.MaxValue).HasValue;
        }
    }
}