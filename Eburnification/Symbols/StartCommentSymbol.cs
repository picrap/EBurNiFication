// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    public class StartCommentSymbol : StringCharacterSymbol<StartCommentSymbol>
    {
        protected override string Character => "(*";
    }
}