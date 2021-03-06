﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    /// <summary>
    ///     terminal-character (§6.2)
    /// </summary>
    public class TerminalCharacter : Symbol<TerminalCharacter>
    {
        public override SymbolKind Kind => SymbolKind.Literal;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAny(parser,
                Letter.Instance, // a
                DecimalDigit.Instance, // b
                ConcatenateSymbol.Instance, // c
                DefiningSymbol.Instance, // d
                DefinitionSeparatorSymbol.Instance, // e
                EndCommentSymbol.Instance, // f
                EndGroupSymbol.Instance, // g
                EndOptionSymbol.Instance, // h
                EndRepeatSymbol.Instance, // i
                ExceptSymbol.Instance, // j
                FirstQuoteSymbol.Instance, // k
                RepetitionSymbol.Instance, // l
                SecondQuoteSymbol.Instance, // m
                SpecialSequenceSymbol.Instance, // n
                StartCommentSymbol.Instance, // o
                StartGroupSymbol.Instance, // p
                StartOptionSymbol.Instance, // q
                StartRepeatSymbol.Instance, // r
                TerminatorSymbol.Instance, // s
                OtherCharacter.Instance // t
            );
        }
    }
}