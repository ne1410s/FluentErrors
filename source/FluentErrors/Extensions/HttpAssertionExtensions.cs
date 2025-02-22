// <copyright file="HttpAssertionExtensions.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentErrors.Errors;

/// <summary>
/// Provides fluent semantics for raising pre-emptive exception types.
/// </summary>
public static class HttpAssertionExtensions
{
    /// <summary>
    /// Asserts that the HTTP response represents success.
    /// </summary>
    /// <param name="response">The HTTP response.</param>
    /// <param name="message">Used if the check fails.</param>
    /// <param name="alsoAllowed">Other allowable statuses (besides 2XX range).</param>
    /// <param name="disallowed">Disallowed status codes.</param>
    /// <param name="unless">Exemption criteria.</param>
    /// <returns>The validated object, for call chaining.</returns>
    /// <exception cref="HttpResponseException">Assertion failed.</exception>
    public static async Task<HttpResponseMessage> MustBeOk(
        this HttpResponseMessage response,
        string? message = null,
        IList<int>? alsoAllowed = null,
        IList<int>? disallowed = null,
        Func<bool>? unless = null)
    {
        response.MustExist();
        disallowed ??= [];
        alsoAllowed ??= [];

        var code = (int)response.StatusCode;
        var ok = !disallowed.Contains(code)
            && (response.IsSuccessStatusCode || alsoAllowed.Contains(code));

        if (unless?.Invoke() != true && !ok)
        {
            var content = await response.Content.ReadAsStringAsync();
            var type = response.Content.Headers.ContentType?.MediaType;
            throw new HttpResponseException(code, type, content);
        }

        return response;
    }
}
