// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class DefinitionSeparatorSymbol : Symbol<DefinitionSeparatorSymbol>
    {
        public override bool TryParse(Parser parser)
        {
            return parser.TryRead('|') || parser.TryRead('/') || parser.TryRead('!');
        }
    }
}