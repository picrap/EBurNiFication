// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class TerminalCharacter : Symbol<TerminalCharacter>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return Letter.Instance.TryParse(tokenizer) // a
                   || DecimalDigit.Instance.TryParse(tokenizer) // b
                   || ConcatenateSymbol.Instance.TryParse(tokenizer) // c
                   || DefiningSymbol.Instance.TryParse(tokenizer) // d
                   || DefinitionSeparatorSymbol.Instance.TryParse(tokenizer) // e
                   || EndCommentSymbol.Instance.TryParse(tokenizer) // f
                   || EndGroupSymbol.Instance.TryParse(tokenizer) // g
                   || EndOptionSymbol.Instance.TryParse(tokenizer) // h
                   || EndRepeatSymbol.Instance.TryParse(tokenizer) // i
                   || ExceptSymbol.Instance.TryParse(tokenizer) // j
                   || FirstQuoteSymbol.Instance.TryParse(tokenizer) // k
                   || RepetitionSymbol.Instance.TryParse(tokenizer) // l
                   || SecondQuoteSymbol.Instance.TryParse(tokenizer) // m
                   || SpecialSequenceSymbol.Instance.TryParse(tokenizer) // n
                   || StartCommentSymbol.Instance.TryParse(tokenizer) // o
                   || StartGroupSymbol.Instance.TryParse(tokenizer) // p
                   || StartOptionSymbol.Instance.TryParse(tokenizer) // q
                   || StartRepeatSymbol.Instance.TryParse(tokenizer) // r
                   || TerminatorSymbol.Instance.TryParse(tokenizer) // s
                   || OtherCharacter.Instance.TryParse(tokenizer) // t
                ;
        }
    }
}