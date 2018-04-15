// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Symbols;

    /// <summary>
    /// Represents a captured text
    /// </summary>
    [DebuggerDisplay("{" + nameof(Value) + "}")]
    public class Token
    {
        /// <summary>
        /// Gets the symbol that captured the value.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public Symbol Symbol { get; }

        /// <summary>
        /// Gets the captured value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public Token[] Children { get; }

        public Token(Symbol symbol, string value, IList<Token> children)
        {
            Symbol = symbol;
            Value = value;
            Children = children.ToArray();
        }
    }
}
