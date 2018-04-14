// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class DefinitionSeparatorSymbol : Symbol<DefinitionSeparatorSymbol>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead('|') || tokenizer.TryRead('/') || tokenizer.TryRead('!');
        }
    }
}