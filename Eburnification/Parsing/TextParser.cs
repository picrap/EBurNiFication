// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(Debug) + "}")]
    public class TextParser : Parser
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

        public override ParserState State
        {
            get { return new TextParserState(_cursor); }
            set { _cursor = ((TextParserState)value).Cursor; }
        }

        public TextParser(string text, int cursor = 0)
        {
            _text = text;
            _cursor = cursor;
        }

        public override char? Peek(int offset)
        {
            var cursor = _cursor + offset;
            return cursor < _text.Length ? _text[cursor] : (char?)null;
        }

        public override void Next(int step)
        {
            _cursor += step;
            if (_cursor > _text.Length)
                _cursor = _text.Length;
        }

        public override string GetCapture(ParserState state)
        {
            var cursor = ((TextParserState)state).Cursor;
            var capture = _text.Substring(cursor, _cursor - cursor);
            return capture;
        }

        public override Parser CreateParser(string text)
        {
            return new TextParser(text);
        }
    }
}