// <copyright file="FakeValidatorsFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Validators.Mocks
{
    using System;
    using TryCatch.Validators;

    public class FakeValidatorsFactory : ValidatorsFactory
    {
        private const string AddValidatorKey = "add-validator";

        private const string AnyComponent = "any-component";

        public FakeValidatorsFactory(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.RegisterType(AddValidatorKey, typeof(AddValidator));
            this.RegisterType(AnyComponent, typeof(FakeComponent));
        }
    }
}
