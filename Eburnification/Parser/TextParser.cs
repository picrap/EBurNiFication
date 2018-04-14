namespace Eburnification.Parser
{
    using System;
    using System.Diagnostics;

    public abstract class Tokenizer
    {
        public abstract Tokenizer CreateSubTokenizer();

        public abstract char? Peek(int offset);
        public abstract void Next(int step);
        public virtual void Next() => Next(1);

        public virtual char? Current => Peek(0);
        public virtual char? ReadNext()
        {
            var c = Current;
            Next();
            return c;
        }

        public virtual bool TryRead(Predicate<char> predicate)
        {
            var current = Current;
            if (!current.HasValue || !predicate(current.Value))
                return false;
            Next();
            return true;
        }

        public virtual bool TryRead(char expectedCharacter) => TryRead(c => c == expectedCharacter);

        public virtual bool TryRead(string expectedCharacter)
        {
            for (int index = 0; index < expectedCharacter.Length; index++)
            {
                if (Peek(index) != expectedCharacter[index])
                    return false;
            }

            Next(expectedCharacter.Length);
            return true;
        }
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

        public override char? Peek(int offset)
        {
            var cursor = _cursor + offset;
            return cursor < _text.Length ? _text[cursor] : (char?)null;
        }

        public override void Next(int step)
        {
            // this is a raw overflow check, but we don't care much
            if (_cursor < _text.Length)
                _cursor += step;
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

    }
}
