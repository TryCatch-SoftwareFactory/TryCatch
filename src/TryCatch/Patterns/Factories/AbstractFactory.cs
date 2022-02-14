// <copyright file="AbstractFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Factories
{
    using System;
    using System.Collections.Generic;
    using TryCatch.Validators;

    /// <summary>
    /// Represents an abstract factory used as a base class to construct specific factories. Pretends to support the common methods used
    /// on the implementations of AbstractFactory and Factory patterns. Allows resolving the constructions of components
    /// using IServiceProvider as a builder of the requested interfaces and components.
    ///
    /// Allows resolving the constructions using key-type or Type-Type pairs. The derivated factories require to define the relations - keyValue -
    /// using the RegisterType methods on the constructor or a similar method with an explicit invocation.
    ///
    /// You can read more about the importance and use of AbstractFactory pattern on: https://en.wikipedia.org/wiki/Abstract_factory_pattern.
    ///
    /// </summary>
    /// <example>
    ///
    ///     public MyFactory(IServiceProvider serviceProvider) : base(serviceProvider)
    ///     {
    ///         this.RegisterType(typeof(AddTaskToDo), typeof(IAddTaskToDoHandler));
    ///     }.
    ///
    /// </example>
    public abstract class AbstractFactory
    {
        private readonly IServiceProvider serviceProvider;

        private readonly IDictionary<string, Type> keyValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> reference to current service provider.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the service provider is null.</exception>
        protected AbstractFactory(IServiceProvider serviceProvider)
        {
            ArgumentsValidator.ThrowIfIsNull(serviceProvider);

            this.serviceProvider = serviceProvider;

            this.keyValues = new Dictionary<string, Type>();
        }

        /// <summary>
        /// Allows registering a new Type-Type relation.
        /// </summary>
        /// <typeparam name="TInput">type of key item.</typeparam>
        /// <typeparam name="TOutput">type of component to be instanced.</typeparam>
        /// <param name="input">A <see cref="TInput"/> reference to be used as a key of the relation.</param>
        /// <param name="output">A <see cref="TOutput"/> reference to be used as a component to be instanced.</param>
        /// <exception cref="ArgumentNullException">It is thrown if any of the arguments are null.</exception>
        /// <exception cref="DuplicateComponentException">It is thrown if the key used in the current relationship was previously registered.</exception>
        /// <returns>Indicates if the register was succeeded.</returns>
        protected virtual bool RegisterType<TInput, TOutput>(TInput input, TOutput output)
            where TInput : Type
            where TOutput : Type
        {
            ArgumentsValidator.ThrowIfIsNull(input, nameof(input));
            ArgumentsValidator.ThrowIfIsNull(output, nameof(output));

            var name = input.Name;

            if (this.keyValues.ContainsKey(input.Name))
            {
                throw new DuplicateComponentException($"Component {name} has been registered before.");
            }

            this.keyValues.Add(input.Name, output);

            return this.keyValues.ContainsKey(input.Name);
        }

        /// <summary>
        /// Allows registering a new Key-Type relation.
        /// </summary>
        /// <typeparam name="TOutput">type of component to be instanced.</typeparam>
        /// <param name="key">Key to be used on the relation.</param>
        /// <param name="output">A <see cref="TOutput"/> reference to be used as a component to be instanced.</param>
        /// <exception cref="ArgumentException">It is thrown if the key is null, empty or whitespace.</exception>
        /// <exception cref="ArgumentNullException">It is thrown if the output is null.</exception>
        /// <exception cref="DuplicateComponentException">It is thrown if the key used in the current relationship was previously registered.</exception>
        /// <returns>Indicates if the register was succeeded.</returns>
        protected virtual bool RegisterType<TOutput>(string key, TOutput output)
            where TOutput : Type
        {
            ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(key);
            ArgumentsValidator.ThrowIfIsNull(output, nameof(output));

            if (this.keyValues.ContainsKey(key))
            {
                throw new DuplicateComponentException($"A component with {key} has been registered before.");
            }

            this.keyValues.Add(key, output);

            return this.keyValues.ContainsKey(key);
        }

        /// <summary>
        /// Allows getting an instance of the component associated with the type used as an argument.
        /// </summary>
        /// <typeparam name="TInput">Type of key-component.</typeparam>
        /// <param name="input">A <see cref="TInput"/> reference to the key component on the relation to resolve.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the input is null.</exception>
        /// <exception cref="ComponentNotFoundException">It is thrown if the component is not registered yet.</exception>
        /// <returns>A <see cref="object"/> reference to the instance of component associated with the type used as an argument.</returns>
        protected virtual object GetType<TInput>(TInput input)
            where TInput : Type
        {
            ArgumentsValidator.ThrowIfIsNull(input, nameof(input));

            var name = input.Name;

            if (!this.keyValues.ContainsKey(name))
            {
                throw new ComponentNotFoundException($"The component named {name} is not found.");
            }

            var handler = this.keyValues[name];

            var service = this.serviceProvider.GetService(handler);

            if (service is null)
            {
                throw new ComponentNotFoundException($"The service component for {name} is not found.");
            }

            return service;
        }

        /// <summary>
        /// Allows getting an instance of the component associated with the key used as an argument.
        /// </summary>
        /// <param name="key">Key used on the relation to resolve.</param>
        /// <exception cref="ArgumentException">It is thrown if the key is null, empty or whitespace.</exception>
        /// <returns>A <see cref="object"/> reference to the instance of component associated with the type used as an argument.</returns>
        protected virtual object GetType(string key)
        {
            ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(key);

            if (!this.keyValues.ContainsKey(key))
            {
                throw new ComponentNotFoundException($"The component with key {key} is not found.");
            }

            var handler = this.keyValues[key];

            var service = this.serviceProvider.GetService(handler);

            if (service is null)
            {
                throw new ComponentNotFoundException($"The service component for {key} is not found.");
            }

            return service;
        }
    }
}
