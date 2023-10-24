// <copyright file="FluentValidatorBase.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Validation;

using System.Linq;
using FluentValidation;
using FluentValidation.Results;

/// <summary>
/// Validates a model of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The model type.</typeparam>
public abstract class FluentValidatorBase<T> : AbstractValidator<T>, IItemValidator<T>
{
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="FluentValidatorBase{T}"/> class.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Critical Code Smell",
        "S1699:Constructors should only call non-overridable methods",
        Justification = "Existing mechanism")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Usage",
        "CA2214:Do not call overridable methods in constructors",
        Justification = "Existing mechanism")]
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

            throw new Errors.ValidatingException(errors);
        }
    }

    /// <summary>
    /// Defines the fluent validation rules.
    /// </summary>
    protected abstract void DefineModelValidity();
}