// <copyright file="IValidatorsFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    /// <summary>
    /// Validator factory interface.
    /// </summary>
    public interface IValidatorsFactory
    {
        /// <summary>
        /// Allows getting an IValidator reference with the key used on their register.
        /// </summary>
        /// <param name="validatorKey">Key associated with IValidator.</param>
        /// <exception cref="System.ArgumentException">It is thrown if the validatorKey is null, empty or whitespace.</exception>
        /// <returns>A <see cref="IValidator"/> reference to the IValidator requested.</returns>
        IValidator GetValidator(string validatorKey);
    }
}
