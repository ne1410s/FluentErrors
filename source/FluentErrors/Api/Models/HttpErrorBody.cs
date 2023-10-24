// <copyright file="HttpErrorBody.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Api.Models;

using System.Collections.Generic;
using FluentErrors.Validation;

/// <summary>
/// Response returned from a unsuccessful http call.
/// </summary>
public class HttpErrorBody
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpErrorBody"/> class.
    /// </summary>
    /// <param name="type">The error type.</param>
    /// <param name="message">The error message.</param>
    /// <param name="errors">Any invalid items associated.</param>
    public HttpErrorBody(string type, string message, IEnumerable<InvalidItem>? errors = null)
    {
        this.Type = type;
        this.Message = message;
        this.Errors = errors;
    }

    /// <summary>
    /// Gets the error type.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets a sequence of invalid items, if present.
    /// </summary>
    public IEnumerable<InvalidItem>? Errors { get; }
}
