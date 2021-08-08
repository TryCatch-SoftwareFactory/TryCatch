// <copyright file="CompositeSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications.InMemory
{
    /// <summary>
    /// Composite Specification Implementation. You can find the original implementation, designed to run in memory,
    /// at the following link: https://en.wikipedia.org/wiki/Specification_pattern.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public abstract class CompositeSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        /// <inheritdoc/>
        public ISpecification<TEntity> And(ISpecification<TEntity> other) => new AndSpecification<TEntity>(this, other);

        /// <inheritdoc/>
        public ISpecification<TEntity> AndNot(ISpecification<TEntity> other) => new AndNotSpecification<TEntity>(this, other);

        /// <inheritdoc/>
        public abstract bool IsSatisfiedBy(TEntity candidate);

        /// <inheritdoc/>
        public ISpecification<TEntity> Not() => new NotSpecification<TEntity>(this);

        /// <inheritdoc/>
        public ISpecification<TEntity> Or(ISpecification<TEntity> other) => new OrSpecification<TEntity>(this, other);

        /// <inheritdoc/>
        public ISpecification<TEntity> OrNot(ISpecification<TEntity> other) => new OrNotSpecification<TEntity>(this, other);
    }
}
