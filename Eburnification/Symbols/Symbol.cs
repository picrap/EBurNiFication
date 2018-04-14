// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public abstract class Symbol
    {
        public abstract bool TryParse(ref Tokenizer tokenizer);

        protected int? TryParseSequence(ref Tokenizer tokenizer, Symbol symbol, int max = int.MaxValue, bool strict = true)
        {
            int count = 0;
            var subTokenizer = tokenizer.CreateSubTokenizer();
            for (; count < max; count++)
            {
                var parsed = symbol.TryParse(ref subTokenizer);
                if (!parsed)
                    break;
            }

            // if max is reached, see if there is nothing behind
            if (strict && count == max)
            {
                var subTokenizer2 = tokenizer.CreateSubTokenizer();
                if (symbol.TryParse(ref subTokenizer2))
                    return null;
            }

            tokenizer = subTokenizer;
            return count;
        }

        protected int? TryParseSequence(ref Tokenizer tokenizer, Symbol symbol, int min, int max, bool strict = true)
        {
            var subTokenizer = tokenizer.CreateSubTokenizer();
            var count = TryParseSequence(ref subTokenizer, symbol, max, strict);
            if (count >= min)
            {
                tokenizer = subTokenizer;
                return count;
            }

            return null;
        }

        //        protected bool TryParse(Symbol start, Symbol )
    }

    public abstract class CharCharacterSymbol : Symbol
    {
        protected abstract char Character { get; }

        public override bool TryParse(ref Tokenizer tokenizer)
        {
            return tokenizer.TryRead(Character);
        }
    }

    public class DefinitionSymbol : CharCharacterSymbol
    {
        protected override char Character => '=';
    }

    public class ConcatenateSymbol : CharCharacterSymbol
    {
        protected override char Character => ',';
    }

    public class TerminatorSymbol : CharCharacterSymbol
    {
        protected override char Character => ';';
    }

    public class FirstQuoteSymbol : CharCharacterSymbol
    {
        protected override char Character => '\'';
    }

    public class SecondQuoteSymbol : CharCharacterSymbol
    {
        protected override char Character => '"';
    }

    public class GapSeparator : Symbol
    {
        public override bool TryParse(ref Tokenizer tokenizer)
        {
            while (tokenizer.TryRead(" ") || tokenizer.TryRead("\t") || tokenizer.TryRead("\n")
                   || tokenizer.TryRead("\r\n") || tokenizer.TryRead("\r"))
            {
            }

            return true;
        }
    }

    public class FirstTerminalCharacter : Symbol
    {
        public override bool TryParse(ref Tokenizer tokenizer)
        {
            return tokenizer.TryRead(c => c != '\'');
        }
    }

    public class SecondTerminalCharacter : Symbol
    {
        public override bool TryParse(ref Tokenizer tokenizer)
        {
            return tokenizer.TryRead(c => c != '\"');
        }
    }

    public class TerminalString : Symbol
    {
        private readonly FirstQuoteSymbol _firstQuoteSymbol = new FirstQuoteSymbol();
        private readonly SecondQuoteSymbol _secondQuoteSymbol = new SecondQuoteSymbol();
        private readonly FirstTerminalCharacter _firstTerminalCharacter = new FirstTerminalCharacter();
        private readonly SecondTerminalCharacter _secondTerminalCharacter = new SecondTerminalCharacter();

        public override bool TryParse(ref Tokenizer tokenizer)
        {
            var st1 = tokenizer.CreateSubTokenizer();
            if (TryParseFirstTerminalString(ref st1))
            {
                tokenizer = st1;
                return true;
            }

            var st2 = tokenizer.CreateSubTokenizer();
            if (TryParseSecondTerminalString(ref st2))
            {
                tokenizer = st2;
                return true;
            }

            return false;
        }

        private bool TryParseFirstTerminalString(ref Tokenizer tokenizer)
        {
            return _firstQuoteSymbol.TryParse(ref tokenizer)
                   && TryParseSequence(ref tokenizer, _firstTerminalCharacter).HasValue
                   && _firstQuoteSymbol.TryParse(ref tokenizer);
        }

        private bool TryParseSecondTerminalString(ref Tokenizer tokenizer)
        {
            return _secondQuoteSymbol.TryParse(ref tokenizer)
                   && TryParseSequence(ref tokenizer, _secondTerminalCharacter).HasValue
                   && _secondQuoteSymbol.TryParse(ref tokenizer);
        }
    }
}