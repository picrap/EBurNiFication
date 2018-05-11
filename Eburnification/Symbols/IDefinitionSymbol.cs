// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    /// <summary>
    ///     Symbol that contains a definition (I found no better idea)
    ///     This assumes
    /// </summary>
    public interface IDefinitionSymbol
    {
        Token GetIdentifier(Token[] tokens);
        Token GetValue(Token[] tokens);
    }
}