// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public interface IRepeatSymbol
    {
        Token GetSymbol(Token[] tokens);
    }
}