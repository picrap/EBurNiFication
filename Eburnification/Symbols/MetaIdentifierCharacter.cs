// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class MetaIdentifierCharacter : Symbol<MetaIdentifierCharacter>
    {
        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(char.IsLetterOrDigit);
        }
    }
}