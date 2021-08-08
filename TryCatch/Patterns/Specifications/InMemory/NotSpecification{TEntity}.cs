// <copyright file="NotSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications.InMemory
{
    using System;
    using TryCatch.Validators;

    /// <summary>
    /// Not Specification Implementation. You can find the original implementation, designed to run in memory,
    /// at the following link: https://en.wikipedia.org/wiki/Specification_pattern.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public sealed class NotSpecification<TEntity> : CompositeSpecification<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> other;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="other">A <see cref="ISpecification{TEntity}"/> reference to the spectification to be negated.</param>
        /// <exception cref="ArgumentNullException">It is thrown if any of the arguments are null.</exception>
        public NotSpecification(ISpecification<TEntity> other)
        {
            ArgumentsValidator.ThrowIfIsNull(other, nameof(other));

            this.other = other;
        }

        /// <inheritdoc/>
        public override bool IsSatisfiedBy(TEntity candidate) => !this.other.IsSatisfiedBy(candidate);
    }
}
