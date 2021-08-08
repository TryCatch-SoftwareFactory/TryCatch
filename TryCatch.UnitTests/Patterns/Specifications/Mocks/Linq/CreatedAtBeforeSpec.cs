// <copyright file="CreatedAtBeforeSpec.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Specifications.Mocks.Linq
{
    using System;
    using System.Linq.Expressions;
    using TryCatch.Patterns.Specifications.Linq;

    public class CreatedAtBeforeSpec : CompositeSpecification<Taxi>
    {
        private readonly DateTime created;

        public CreatedAtBeforeSpec(DateTime created)
        {
            this.created = created;
        }

        public override Expression<Func<Taxi, bool>> AsExpression() => (candidate) => candidate.CreatedAt < this.created;
    }
}
