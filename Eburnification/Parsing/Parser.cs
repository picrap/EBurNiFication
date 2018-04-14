// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System;

    public abstract class Parser
    {
        /// <summary>
        /// Gets or sets the state.
        /// This allows to rollback on complex parsing
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public abstract ParserState State { get; set; }

        public abstract char? Peek(int offset);
        public virtual char? Peek() => Peek(0);
        public abstract void Next(int step);
        public virtual void Next() => Next(1);

        // TODO: remove?
        public virtual char? Current => Peek();

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
        public abstract string GetCapture(ParserState state);
    }
}