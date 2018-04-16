// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class MetaIdentifier : Symbol<MetaIdentifier>
    {
        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            if (!parser.TryRead(char.IsLetter))
                return AnyToken.None;
            // which is actually always true, since we ask for as many as we wantd
            return tokenizer.ParseSequence(parser, MetaIdentifierCharacter.Instance, int.MaxValue);
        }
    }
}