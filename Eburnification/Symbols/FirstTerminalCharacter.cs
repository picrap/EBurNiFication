// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class FirstTerminalCharacter : Symbol<FirstTerminalCharacter>
    {
        public override bool TryParse(Parser parser)
        {
            return parser.TryRead(c => c != '\'');
        }
    }
}