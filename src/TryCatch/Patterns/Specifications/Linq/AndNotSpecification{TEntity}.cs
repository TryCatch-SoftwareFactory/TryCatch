// <copyright file="AndNotSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications.Linq
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using TryCatch.Validators;

    /// <summary>
    /// And Not spec implementation with linq.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public sealed class AndNotSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        private readonly ISpecification<TEntity> left;

        private readonly ISpecification<TEntity> right;

        /// <summary>
        /// Initializes a new instance of the <see cref="AndNotSpecification{TEntity}"/> class.
        /// </summary>
        /// <param name="left">A <see cref="ISpecification{TEntity}"/> reference to the left argument.</param>
        /// <param name="right">A <see cref="ISpecification{TEntity}"/> reference to the right argument.</param>
        /// <exception cref="ArgumentNullException">It is thrown if any of the arguments are null.</exception>
        public AndNotSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        {
            ArgumentsValidator.ThrowIfIsNull(left, nameof(left));
            ArgumentsValidator.ThrowIfIsNull(right, nameof(right));

            this.left = left;
            this.right = right;
        }

        /// <inheritdoc/>
        public override Expression<Func<TEntity, bool>> AsExpression()
        {
            var leftExpression = (this.left is ILinqSpecification<TEntity> left)
                ? left.AsExpression()
                : (TEntity candidate) => this.left.IsSatisfiedBy(candidate);

            var rightExpression = (this.right is ILinqSpecification<TEntity> right)
                ? right.AsExpression()
                : (TEntity candidate) => !this.right.IsSatisfiedBy(candidate);

            var not = Expression.Lambda<Func<TEntity, bool>>(
                Expression.Not(rightExpression.Body),
                rightExpression.Parameters[0]);

            var invokedExpr = Expression.Invoke(not, leftExpression.Parameters.Cast<Expression>());

            var andAlso = Expression.AndAlso(leftExpression.Body, invokedExpr);

            return Expression.Lambda<Func<TEntity, bool>>(andAlso, leftExpression.Parameters);
        }
    }
}
