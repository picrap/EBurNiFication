// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using System.Linq;
    using Parser;

    public class OtherCharacter : Symbol<OtherCharacter>
    {
        private static readonly IEnumerable<char> OtherCharacters = " .:!+_%@&#$<>/\\~^";

        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(c => OtherCharacters.Contains(c));
        }
    }
}