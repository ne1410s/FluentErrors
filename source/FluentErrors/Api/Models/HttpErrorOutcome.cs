// <copyright file="HttpErrorOutcome.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Api.Models;

/// <summary>
/// An http error outcome.
/// </summary>
public class HttpErrorOutcome
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpErrorOutcome"/> class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="errorBody">The error body.</param>
    public HttpErrorOutcome(int errorCode, HttpErrorBody errorBody)
    {
        this.ErrorCode = errorCode;
        this.ErrorBody = errorBody;
    }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public int ErrorCode { get; }

    /// <summary>
    /// Gets the error body.
    /// </summary>
    public HttpErrorBody ErrorBody { get; }
}