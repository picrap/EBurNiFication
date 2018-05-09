// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    public class RepetitionSymbol : CharCharacterSymbol<RepetitionSymbol>
    {
        protected override char Character => '*';
    }
}