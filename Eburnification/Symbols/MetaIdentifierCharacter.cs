// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class MetaIdentifierCharacter : Symbol<MetaIdentifierCharacter>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(char.IsLetterOrDigit) ? NoToken() : null;
        }
    }
}