// <copyright file="FluentValidatorBase.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Validation
{
    using System.Linq;
    using FluentErrors.Errors;
    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>
    /// Validates a model of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract class FluentValidatorBase<T> : AbstractValidator<T>, IItemValidator<T>
    {
        /// <summary>
        /// Initialises a new instance of the
        /// <see cref="FluentValidatorBase{T}"/> class.
        /// </summary>
        protected FluentValidatorBase()
        {
            this.DefineModelValidity();
        }

        /// <inheritdoc/>
        public virtual void AssertValid(T item)
        {
            ValidationResult result = this.Validate(item);
            if (!result.IsValid)
            {
                var errors = result.Errors
                    .Select(e => new InvalidItem(e.PropertyName, e.ErrorMessage, e.AttemptedValue))
                    .ToArray();

                throw new ValidationError(errors);
            }
        }

        /// <summary>
        /// Defines the fluent validation rules.
        /// </summary>
        protected abstract void DefineModelValidity();
    }
}