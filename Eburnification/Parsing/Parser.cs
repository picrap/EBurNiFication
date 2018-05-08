// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System;

    public abstract class Parser
    {
        /// <summary>
        ///     Gets or sets the state.
        ///     This allows to rollback on complex parsing
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        public abstract ParserState State { get; set; }

        /// <summary>
        ///     Gets the <see cref="char" /> at specified offset from current position.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <returns>a valid character or null if the end is reached</returns>
        public abstract char? Peek(int offset);

        /// <summary>
        ///     Gets the <see cref="char" /> at current position.
        /// </summary>
        /// <returns>a valid character or null if the end is reached</returns>
        public virtual char? Peek() => Peek(0);

        /// <summary>
        ///     Moves to a forward position.
        /// </summary>
        /// <param name="step">The step to move.</param>
        public abstract void Next(int step);

        /// <summary>
        ///     Moves to a forward position.
        /// </summary>
        public virtual void Next() => Next(1);

        /// <summary>
        ///     Gets a value indicating whether the end is reached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is end; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsEnd => Peek() == null;

        /// <summary>
        ///     Tries to read a <see cref="char" /> that matches predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public virtual bool TryRead(Predicate<char> predicate)
        {
            var current = Peek();
            if (!current.HasValue || !predicate(current.Value))
                return false;
            Next();
            return true;
        }

        /// <summary>
        ///     Tries to read a specific <see cref="char" />.
        /// </summary>
        /// <param name="expectedCharacter">The expected character.</param>
        /// <returns></returns>
        public virtual bool TryRead(char expectedCharacter) => TryRead(c => c == expectedCharacter);

        /// <summary>
        ///     Tries to read a given string.
        /// </summary>
        /// <param name="expectedCharacter">The expected character.</param>
        /// <returns></returns>
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
        ///     Gets the capture from saved state to current state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public abstract string GetCapture(ParserState state);

        /// <summary>
        ///     Creates a sub parser, which allows to parse from given state to current position.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns></returns>
        public abstract Parser CreateSubParser(ParserState from);
    }
}