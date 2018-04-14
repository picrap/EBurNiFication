// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class MetaIdentifierCharacter : Symbol<MetaIdentifierCharacter>
    {
        public override bool TryParse(Parser parser)
        {
            return parser.TryRead(char.IsLetterOrDigit);
        }
    }
}