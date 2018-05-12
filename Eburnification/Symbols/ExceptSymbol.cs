// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class ExceptSymbol : Symbol
    {
        private readonly Symbol _include;
        private readonly Symbol _except;

        public ExceptSymbol(Symbol include, Symbol except)
        {
            _include = include;
            _except = except;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            var state = parser.State;

            var includeResult = tokenizer.Parse(parser, _include);
            if (includeResult.IsNone)
                return includeResult;

            var afterInclude = parser.State;
            // rollback to test if it is not the exception
            parser.State = state;
            var exceptResult = tokenizer.Parse(parser, _except);
            if (exceptResult.IsNone)
            {
                parser.State = afterInclude;
                return includeResult;
            }

            parser.State = state;
            return ParsingResult.None;
        }
    }
}