// <copyright file="FakeFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Factories.Mocks
{
    using System;
    using TryCatch.Patterns.Factories;

    public class FakeFactory : AbstractFactory
    {
        public FakeFactory(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public new bool RegisterType<TInput, TOutput>(TInput input, TOutput output)
            where TInput : Type
            where TOutput : Type => base.RegisterType(input, output);

        public new bool RegisterType<TOutput>(string key, TOutput output)
            where TOutput : Type => base.RegisterType(key, output);

        public new object GetType<TInput>(TInput input)
            where TInput : Type => base.GetType(input);

        public new object GetType(string key) => base.GetType(key);
    }
}
