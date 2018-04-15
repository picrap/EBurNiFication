// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class TerminalCharacter : Symbol<TerminalCharacter>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(tokenizer.ParseAny(parser, 
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
            ));
        }
    }
}