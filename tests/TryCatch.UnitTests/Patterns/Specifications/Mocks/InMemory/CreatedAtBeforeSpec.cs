// <copyright file="CreatedAtBeforeSpec.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Specifications.Mocks.InMemory
{
    using System;
    using TryCatch.Patterns.Specifications.InMemory;

    public class CreatedAtBeforeSpec : CompositeSpecification<Taxi>
    {
        private readonly DateTime created;

        public CreatedAtBeforeSpec(DateTime created)
        {
            this.created = created;
        }

        public override bool IsSatisfiedBy(Taxi candidate) => candidate.CreatedAt < this.created;
    }
}
