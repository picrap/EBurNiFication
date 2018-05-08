﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    public class FirstQuoteSymbol : CharCharacterSymbol<FirstQuoteSymbol>
    {
        public override bool IsGapFreeSymbol => false;

        protected override char Character => '\'';
    }
}