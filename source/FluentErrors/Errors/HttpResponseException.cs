// <copyright file="HttpResponseException.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors;

/// <summary>
/// Unexpected http status errors.
/// </summary>
/// <param name="status">The status code.</param>
/// <param name="contentType">The content type.</param>
/// <param name="content">The content.</param>
public class HttpResponseException(int status, string? contentType, string? content)
    : DataStateException($"Unexpected HTTP response status: {status}")
{
    /// <summary>
    /// Gets the status code.
    /// </summary>
    public int Status { get; } = status;

    /// <summary>
    /// Gets the content type.
    /// </summary>
    public string? ContentType { get; } = contentType;

    /// <summary>
    /// Gets the content.
    /// </summary>
    public string? Content { get; } = content;
}
