// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class SecondTerminalCharacter : Symbol<SecondTerminalCharacter>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(parser.TryRead(c => c != '\"'));
        }
    }
}