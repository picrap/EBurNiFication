// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class TerminalCharacter : Symbol<TerminalCharacter>
    {
        public override bool TryParse(Parser parser)
        {
            return Letter.Instance.TryParse(parser) // a
                   || DecimalDigit.Instance.TryParse(parser) // b
                   || ConcatenateSymbol.Instance.TryParse(parser) // c
                   || DefiningSymbol.Instance.TryParse(parser) // d
                   || DefinitionSeparatorSymbol.Instance.TryParse(parser) // e
                   || EndCommentSymbol.Instance.TryParse(parser) // f
                   || EndGroupSymbol.Instance.TryParse(parser) // g
                   || EndOptionSymbol.Instance.TryParse(parser) // h
                   || EndRepeatSymbol.Instance.TryParse(parser) // i
                   || ExceptSymbol.Instance.TryParse(parser) // j
                   || FirstQuoteSymbol.Instance.TryParse(parser) // k
                   || RepetitionSymbol.Instance.TryParse(parser) // l
                   || SecondQuoteSymbol.Instance.TryParse(parser) // m
                   || SpecialSequenceSymbol.Instance.TryParse(parser) // n
                   || StartCommentSymbol.Instance.TryParse(parser) // o
                   || StartGroupSymbol.Instance.TryParse(parser) // p
                   || StartOptionSymbol.Instance.TryParse(parser) // q
                   || StartRepeatSymbol.Instance.TryParse(parser) // r
                   || TerminatorSymbol.Instance.TryParse(parser) // s
                   || OtherCharacter.Instance.TryParse(parser) // t
                ;
        }
    }
}