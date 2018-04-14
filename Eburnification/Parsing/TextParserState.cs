// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    public class TextParserState : ParserState
    {
        public int Cursor { get; }

        public TextParserState(int cursor)
        {
            Cursor = cursor;
        }
    }
}