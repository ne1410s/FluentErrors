// <copyright file="ServiceOrchestrationException.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors;

using System;

/// <summary>
/// Represents errors occuring in general domain processing.
/// </summary>
public class ServiceOrchestrationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceOrchestrationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public ServiceOrchestrationException(string? message)
        : base(message)
    { }
}