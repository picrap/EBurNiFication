﻿namespace Eburnification.Symbols
{
    using Parsing;

    public class EmptySequence: Symbol<EmptySequence>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            var state = parser.State;
            var parsingResult = TerminalCharacter.Instance.TryParse(tokenizer, parser);
            if(parsingResult.IsNone)
                return ParsingResult.Empty;
            parser.State = state;
            return ParsingResult.None;
        }
    }
}