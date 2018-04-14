// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parser
{
    using System;

    public abstract class Tokenizer
    {
        public abstract Tokenizer CreateSubTokenizer();

        public abstract char? Peek(int offset);
        public abstract void Next(int step);
        public virtual void Next() => Next(1);

        public virtual char? Current => Peek(0);

        public virtual char? ReadNext()
        {
            var c = Current;
            Next();
            return c;
        }

        public virtual bool TryRead(Predicate<char> predicate)
        {
            var current = Current;
            if (!current.HasValue || !predicate(current.Value))
                return false;
            Next();
            return true;
        }

        public virtual bool TryRead(char expectedCharacter) => TryRead(c => c == expectedCharacter);

        public virtual bool TryRead(string expectedCharacter)
        {
            for (int index = 0; index < expectedCharacter.Length; index++)
            {
                if (Peek(index) != expectedCharacter[index])
                    return false;
            }

            Next(expectedCharacter.Length);
            return true;
        }
    }
}