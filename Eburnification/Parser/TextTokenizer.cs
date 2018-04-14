// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parser
{
    using System.Diagnostics;

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
            return cursor < _text.Length ? _text[cursor] : (char?) null;
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