// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parser
{
    public class TextTokenizerState : TokenizerState
    {
        public int Cursor { get; }

        public TextTokenizerState(int cursor)
        {
            Cursor = cursor;
        }
    }
}