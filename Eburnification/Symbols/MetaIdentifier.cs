// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class MetaIdentifier : Symbol<MetaIdentifier>
    {
        private readonly MetaIdentifierCharacter _metaIdentifierCharacter = new MetaIdentifierCharacter();

        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            if (!parser.TryRead(char.IsLetter))
                return null;
            // which is actually always true, since we ask for as many as we wantd
            return tokenizer.ParseSequence(parser, _metaIdentifierCharacter, int.MaxValue);
        }
    }
}