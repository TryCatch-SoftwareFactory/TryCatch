// <copyright file="ISpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications
{
    /// <summary>
    /// Specification pattern interface. Allows separating the business rules on queries from the
    /// persistence layer as two components: spec builder & data access object. This way also allows
    /// reusing business rules containers (specs). For a more detailed explication, please refer to
    /// the original definition from Martin Fowler and Eric Evans on: https://martinfowler.com/apsupp/spec.pdf.
    ///
    /// You can find the original implementation at the following link: https://en.wikipedia.org/wiki/Specification_pattern.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public interface ISpecification<TEntity>
    {
        /// <summary>
        /// Indicates if the spec is satisfied for the candidate.
        /// </summary>
        /// <param name="candidate">A <see cref="TEntity"/> reference to the candidate.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the candidate is null.</exception>
        /// <returns>Indicate if is satisfied.</returns>
        bool IsSatisfiedBy(TEntity candidate);

        /// <summary>
        /// Allows adding a spec condition with an And operator.
        /// </summary>
        /// <param name="other">A <see cref="ISpecification{TEntity}"/> reference to the other spec.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the spec is null.</exception>
        /// <returns>A <see cref="ISpecification{TEntity}"/> reference to the ISpecification composited.</returns>
        ISpecification<TEntity> And(ISpecification<TEntity> other);

        /// <summary>
        /// Allows adding a spec condition with an And Not operator.
        /// </summary>
        /// <param name="other">A <see cref="ISpecification{TEntity}"/> reference to the other spec.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the spec is null.</exception>
        /// <returns>A <see cref="ISpecification{TEntity}"/> reference to the ISpecification composited.</returns>
        ISpecification<TEntity> AndNot(ISpecification<TEntity> other);

        /// <summary>
        /// Allows adding a spec condition with an Or operator.
        /// </summary>
        /// <param name="other">A <see cref="ISpecification{TEntity}"/> reference to the other spec.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the spec is null.</exception>
        /// <returns>A <see cref="ISpecification{TEntity}"/> reference to the ISpecification composited.</returns>
        ISpecification<TEntity> Or(ISpecification<TEntity> other);

        /// <summary>
        /// Allows adding a spec condition with an Or Not operator.
        /// </summary>
        /// <param name="other">A <see cref="ISpecification{TEntity}"/> reference to the other spec.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the spec is null.</exception>
        /// <returns>A <see cref="ISpecification{TEntity}"/> reference to the ISpecification composited.</returns>
        ISpecification<TEntity> OrNot(ISpecification<TEntity> other);

        /// <summary>
        /// Allows adding a spec condition with a Not operator.
        /// </summary>
        /// <returns>A <see cref="ISpecification{TEntity}"/> reference to the ISpecification composited.</returns>
        ISpecification<TEntity> Not();
    }
}
