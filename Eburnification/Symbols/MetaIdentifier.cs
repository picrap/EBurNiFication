// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class MetaIdentifier : Symbol<MetaIdentifier>
    {
        private readonly MetaIdentifierCharacter _metaIdentifierCharacter = new MetaIdentifierCharacter();

        public override bool TryParse(Parser parser)
        {
            if (!parser.TryRead(char.IsLetter))
                return false;
            // which is actually always true, since we ask for as many as we wantd
            return TryParseSequence(parser, _metaIdentifierCharacter, 0, int.MaxValue).HasValue;
        }
    }
}