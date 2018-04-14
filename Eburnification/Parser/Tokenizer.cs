﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parser
{
    using System;

    public abstract class Tokenizer
    {
        /// <summary>
        /// Gets or sets the state.
        /// This allows to rollback on complex parsing
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public abstract TokenizerState State { get; set; }

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

        /// <summary>
        /// Gets the capture from saved state to current state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public abstract string GetCapture(TokenizerState state);
    }
}