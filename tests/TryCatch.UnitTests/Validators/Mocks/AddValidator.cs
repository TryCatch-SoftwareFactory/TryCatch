// <copyright file="AddValidator.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Validators.Mocks
{
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Validators;

    public class AddValidator : IValidator
    {
        public ValidationResult Validate<TEntity>(TEntity entity) => new ValidationResult();

        public void ValidateAndThrowIfError<TEntity>(TEntity entity)
        {
        }

        public async Task ValidateAndThrowIfErrorAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) =>
            await Task.CompletedTask.ConfigureAwait(false);

        public async Task<ValidationResult> ValidateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) =>
            await Task.FromResult(new ValidationResult()).ConfigureAwait(false);
    }
}
