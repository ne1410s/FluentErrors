// <copyright file="ResourceMissingException.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors;

/// <summary>
/// Missing resource errors.
/// </summary>
public class ResourceMissingException : DataStateException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceMissingException"/>
    /// class.
    /// </summary>
    /// <param name="message">A description of the exception.</param>
    public ResourceMissingException(string? message = null)
        : base(message ?? "Resource not found")
    { }
}