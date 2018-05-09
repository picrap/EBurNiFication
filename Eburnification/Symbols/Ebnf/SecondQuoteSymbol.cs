// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    public class SecondQuoteSymbol : CharCharacterSymbol<SecondQuoteSymbol>
    {
        public override bool IsGapFreeSymbol => false;

        protected override char Character => '"';
    }
}