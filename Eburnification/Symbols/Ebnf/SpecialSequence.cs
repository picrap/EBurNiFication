// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Parsing;

    /// <summary>
    ///     special-sequence (§5.11)
    /// </summary>
    public class SpecialSequence : Symbol<SpecialSequence>
    {
        public override bool IsCommentlessSymbol => true;

        public override bool IsSignificant => false;

        private readonly Symbol _specialSequenceSymbols = new RepeatSymbol(SpecialSequenceCharacter.Instance);

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            var state = parser.State;

            var parsingResult = tokenizer.ParseAll(parser, SpecialSequenceSymbol.Instance, _specialSequenceSymbols, SpecialSequenceSymbol.Instance);
            if (parsingResult.IsNone)
                return parsingResult;

            var sequenceName = parsingResult.Tokens[1].Value.Trim();
            var anyOf = tokenizer.GetSpecialSequence(sequenceName);
            var noToken = new Token[0];
            var tokens = anyOf.Select(s => new Token(new LiteralSymbol(s), s, noToken)).ToArray();
            var orSymbol = new OrSymbol();
            var token = new Token(orSymbol, parser.GetCapture(state), tokens);
            return token;
        }
    }
}