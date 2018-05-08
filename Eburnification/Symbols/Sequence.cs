﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    internal class Sequence : Symbol
    {
        private readonly Symbol[] _symbols;

        public Sequence(params Symbol[] symbols)
        {
            _symbols = symbols;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, _symbols);
        }
    }
}