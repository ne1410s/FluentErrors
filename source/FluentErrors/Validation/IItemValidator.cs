// <copyright file="IItemValidator.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Validation;

using FluentErrors.Errors;

/// <summary>
/// Validates an item.
/// </summary>
/// <typeparam name="TItem">The item type.</typeparam>
public interface IItemValidator<in TItem>
{
    /// <summary>
    /// Validates an item.
    /// </summary>
    /// <param name="item">The item to validate.</param>
    /// <exception cref="ValidatingException">Invalid data.</exception>
    public void AssertValid(TItem item);
}