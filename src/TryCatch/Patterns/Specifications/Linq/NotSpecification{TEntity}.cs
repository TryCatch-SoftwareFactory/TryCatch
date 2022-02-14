// <copyright file="NotSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications.Linq
{
    using System;
    using System.Linq.Expressions;
    using TryCatch.Validators;

    /// <summary>
    /// Not Specification Implementation with linq.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public sealed class NotSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> other;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="other">A <see cref="ISpecification{TEntity}"/> reference to the specification to be negated.</param>
        /// <exception cref="ArgumentNullException">It is thrown if any of the arguments are null.</exception>
        public NotSpecification(ISpecification<TEntity> other)
        {
            ArgumentsValidator.ThrowIfIsNull(other, nameof(other));

            this.other = other;
        }

        /// <inheritdoc/>
        public override Expression<Func<TEntity, bool>> AsExpression()
        {
            var otherExpression = (this.other is ILinqSpecification<TEntity> other)
                ? other.AsExpression()
                : (TEntity candidate) => this.other.IsSatisfiedBy(candidate);

            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(otherExpression.Body), otherExpression.Parameters);
        }
    }
}
