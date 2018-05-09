// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    public class StartRepeatSymbol : CharCharacterSymbol<StartRepeatSymbol>
    {
        protected override char Character => '{';
    }
}