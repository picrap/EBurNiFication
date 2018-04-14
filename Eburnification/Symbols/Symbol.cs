// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System;
    using Parser;

    public abstract class Symbol
    {
        /// <summary>
        /// Tries to parse symbol from current tokenizer.
        /// </summary>
        /// <param name="tokenizer">The tokenizer.</param>
        /// <returns></returns>
        public abstract bool TryParse(Tokenizer tokenizer);

        protected bool TryParse(Tokenizer tokenizer, Predicate<Tokenizer> tryParse)
        {
            var s = tokenizer.State;
            var result = tryParse(tokenizer);
            if (!result)
                tokenizer.State = s;
            return result;
        }

        protected int? TryParseSequence(Tokenizer tokenizer, Symbol symbol, int max = int.MaxValue, bool strict = true)
        {
            int count = 0;
            for (; count < max; count++)
            {
                var parsed = symbol.TryParse(tokenizer);
                if (!parsed)
                    break;
            }

            // if max is reached, see if there is nothing behind
            if (strict && count == max)
            {
                var s = tokenizer.State;
                if (symbol.TryParse(tokenizer))
                {
                    tokenizer.State = s;
                    return null;
                }
            }

            return count;
        }

        protected int? TryParseSequence(Tokenizer tokenizer, Symbol symbol, int min, int max, bool strict = true)
        {
            var s = tokenizer.State;
            var count = TryParseSequence(tokenizer, symbol, max, strict);
            if (count >= min)
                return count;

            tokenizer.State = s;
            return null;
        }
    }

    public abstract class CharCharacterSymbol : Symbol
    {
        protected abstract char Character { get; }

        public override bool TryParse(Tokenizer tokenizer)
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
        public override bool TryParse(Tokenizer tokenizer)
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
        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(c => c != '\'');
        }
    }

    public class SecondTerminalCharacter : Symbol
    {
        public override bool TryParse(Tokenizer tokenizer)
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

        public override bool TryParse(Tokenizer tokenizer)
        {
            return TryParse(tokenizer, TryParseFirstTerminalString)
                   || TryParse(tokenizer, TryParseSecondTerminalString);
        }

        private bool TryParseFirstTerminalString(Tokenizer tokenizer)
        {
            return _firstQuoteSymbol.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, _firstTerminalCharacter).HasValue
                   && _firstQuoteSymbol.TryParse(tokenizer);
        }

        private bool TryParseSecondTerminalString(Tokenizer tokenizer)
        {
            return _secondQuoteSymbol.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, _secondTerminalCharacter).HasValue
                   && _secondQuoteSymbol.TryParse(tokenizer);
        }
    }
}