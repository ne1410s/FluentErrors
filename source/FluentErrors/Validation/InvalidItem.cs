// <copyright file="InvalidItem.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Validation;

/// <summary>
/// Represents an invalid item.
/// </summary>
public class InvalidItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidItem"/> class.
    /// </summary>
    /// <param name="property">The property name.</param>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="attemptedValue">The attempted value.</param>
    public InvalidItem(string property, string errorMessage, object? attemptedValue)
    {
        this.Property = property;
        this.ErrorMessage = errorMessage;
        this.AttemptedValue = attemptedValue;
    }

    /// <summary>
    /// Gets the property name.
    /// </summary>
    public string Property { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string ErrorMessage { get; }

    /// <summary>
    /// Gets the attempted value.
    /// </summary>
    public object? AttemptedValue { get; }
}