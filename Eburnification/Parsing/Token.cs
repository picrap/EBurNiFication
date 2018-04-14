// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using Symbols;

    public class Token
    {
        public Symbol Symbol { get; }

        public string Value { get; }

        public Token[] Children { get; }
    }
}