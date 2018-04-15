// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class DefinitionSeparatorSymbol : Symbol<DefinitionSeparatorSymbol>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead('|') || parser.TryRead('/') || parser.TryRead('!') ? NoToken() : null;
        }
    }
}