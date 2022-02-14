// <copyright file="ValidatorsFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    using System;
    using TryCatch.Patterns.Factories;

    /// <summary>
    /// Abstract base class to implement a factory for the validators creation process. Allows getting validators through their keys associated previously.
    /// You must define the key-value dictionary on the constructor using the Register method (protected).
    /// </summary>
    /// <example>
    ///
    ///     public MyValidatorsFactory(IServiceProvider serviceProvider) : base(serviceProvider)
    ///     {
    ///         this.RegisterType("car-creating", typeof(ICarCreationValidator));
    ///         this.RegisterType("car-updating", typeof(ICarUpdatingValidator));
    ///     }.
    ///
    /// </example>
    public abstract class ValidatorsFactory : AbstractFactory, IValidatorsFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorsFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> reference to the service provider.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the service provider is null.</exception>
        protected ValidatorsFactory(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        /// <summary>
        /// Allows getting a specific IValidator reference by their associated key.
        /// </summary>
        /// <param name="validatorKey">Associated key.</param>
        /// <exception cref="ArgumentException">It is thrown if the validatorKey is null, empty or whitespace.</exception>
        /// <returns>A <see cref="IValidator"/> reference to the requested validator.</returns>
        public virtual IValidator GetValidator(string validatorKey)
        {
            ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(validatorKey);

            if (!(this.GetType(validatorKey) is IValidator validator))
            {
                throw new ValidatorNotFoundException($"Not found validator for key: {validatorKey}.");
            }

            return validator;
        }
    }
}
