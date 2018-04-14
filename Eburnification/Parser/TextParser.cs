namespace Eburnification.Parser
{
    using System;
    using System.Diagnostics;

    public abstract class Tokenizer
    {
        public abstract Tokenizer CreateSubTokenizer();

        public virtual Tokenizer SkipNonSignificant()
        {
            return this;
        }

        public abstract char? ReadNext();
        public abstract char? Current { get; }

        public virtual bool TryRead(Predicate<char> predicate)
        {
            var current = Current;
            if (!current.HasValue || !predicate(current.Value))
                return false;
            // TODO a simple Next()
            ReadNext();
            return true;
        }

        public abstract bool TryRead(string expectedCharacter);
        public abstract bool TryRead(char expectedCharacter);
    }

    [DebuggerDisplay("{" + nameof(Debug) + "}")]
    public class TextTokenizer : Tokenizer
    {
        private readonly string _text;
        private int _cursor;

        private string Debug
        {
            get
            {
                if (_cursor > _text.Length)
                    return "<end>";
                var start = _text.Substring(_cursor);
                if (start.Length < 10)
                    return start;
                return start.Substring(0, 10) + "[...]";
            }
        }

        public override char? Current => Get(_cursor);

        private char? Get(int cursor)
        {
            return cursor < _text.Length ? _text[cursor] : (char?)null;
        }

        public TextTokenizer(string text, int cursor = 0)
        {
            _text = text;
            _cursor = cursor;
        }

        public override Tokenizer CreateSubTokenizer()
        {
            return new TextTokenizer(_text, _cursor);
        }

        public override Tokenizer SkipNonSignificant()
        {
            for (; ; )
            {
                var c = Current;
                if (!c.HasValue || !char.IsWhiteSpace(c.Value))
                    break;
                Next();
            }

            return this;
        }

        private void Next()
        {
            if (_cursor < _text.Length)
                _cursor++;
        }

        public override char? ReadNext()
        {
            var c = Current;
            Next();
            return c;
        }

        public override bool TryRead(string expectedCharacter)
        {
            for (int index = 0; index < expectedCharacter.Length; index++)
            {
                if (Get(_cursor + index) != expectedCharacter[index])
                    return false;
            }

            _cursor += expectedCharacter.Length;
            return true;
        }

        public override bool TryRead(char expectedCharacter)
        {
            if (Current != expectedCharacter)
                return false;
            _cursor++;
            return true;
        }
    }
}
