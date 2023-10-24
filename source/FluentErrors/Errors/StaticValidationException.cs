// <copyright file="StaticValidationException.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors;

using FluentErrors.Validation;

/// <summary>
/// Represents errors occuring during static validation.
/// </summary>
public class StaticValidationException : ValidatingException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StaticValidationException"/>
    /// class.
    /// </summary>
    /// <param name="invalidItems">Invalid items.</param>
    public StaticValidationException(params InvalidItem[] invalidItems)
        : base(invalidItems)
    { }
}