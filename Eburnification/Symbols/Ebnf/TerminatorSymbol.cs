﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    public class TerminatorSymbol : CharCharacterSymbol<TerminatorSymbol>
    {
        protected override char Character => ';';
    }
}