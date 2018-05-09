// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    public class EndCommentSymbol : StringCharacterSymbol<EndCommentSymbol>
    {
        protected override string Character => "*)";
    }
}