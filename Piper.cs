using System;

namespace SparkySimp.LibPipes
{
    /// <summary>
    /// Contains methods for passing output from a function to another one idiomatically.
    /// </summary>
    public static class Piper
    {
        /// <summary>
        /// Feeds one function's input with another function's output.
        /// </summary>
        /// <typeparam name="TIn">Type for this value, which will be piped down.</typeparam>
        /// <typeparam name="TOut">Type for the operation result.</typeparam>
        /// <param name="self">The object to pipe down.</param>
        /// <param name="pipe">The function which will process this object.</param>
        /// <returns>The result of the applied function.</returns>
        public static TOut Pipe<TIn, TOut>(this TIn self, Func<TIn, TOut> pipe) => pipe(self);
    }
}
