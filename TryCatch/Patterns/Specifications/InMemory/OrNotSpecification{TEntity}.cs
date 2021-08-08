// <copyright file="OrNotSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications.InMemory
{
    using System;
    using TryCatch.Validators;

    /// <summary>
    /// Or not Specification Implementation. You can find the original implementation, designed to run in memory,
    /// at the following link: https://en.wikipedia.org/wiki/Specification_pattern.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public sealed class OrNotSpecification<TEntity> : CompositeSpecification<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> left;

        private readonly ISpecification<TEntity> right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrNotSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="left">A <see cref="ISpecification{TEntity}"/> reference to the left argument.</param>
        /// <param name="right">A <see cref="ISpecification{TEntity}"/> reference to the right argument.</param>
        /// <exception cref="ArgumentNullException">It is thrown if any of the arguments are null.</exception>
        public OrNotSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            ArgumentsValidator.ThrowIfIsNull(left, nameof(left));
            ArgumentsValidator.ThrowIfIsNull(right, nameof(right));

            this.left = left;
            this.right = right;
        }

        /// <inheritdoc/>
        public override bool IsSatisfiedBy(TEntity candidate) =>
            this.left.IsSatisfiedBy(candidate)
                || !this.right.IsSatisfiedBy(candidate);
    }
}
