// <copyright file="IEntityTranslator.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns
{
    /// <summary>
    /// Base interface to implement the "Entity Translator" pattern. It has as main goal supply an easy
    /// mechanism to transform or translate reference between API messages and business model and vice-versa.
    /// To have more details, please refer to:
    /// https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff647889(v=pandp.10)?redirectedfrom=MSDN .
    /// </summary>
    public interface IEntityTranslator
    {
        /// <summary>
        /// Allows to translate or transform the input reference to a new TOut's reference.
        /// </summary>
        /// <typeparam name="TOut">Target type of translation.</typeparam>
        /// <typeparam name="TIn">Input type of translation.</typeparam>
        /// <param name="source">A <see cref="TIn"/> reference to input type.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the source is null.</exception>
        /// <returns>A <see cref="TOut"/> new TOut's reference with the result of translation.</returns>
        TOut Translate<TOut, TIn>(TIn source)
            where TIn : class
            where TOut : class;
    }
}
