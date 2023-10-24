// <copyright file="DataStateException.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors;

/// <summary>
/// Represents errors occuring due to the state of data in the store.
/// </summary>
public class DataStateException : ServiceOrchestrationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataStateException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public DataStateException(string? message)
        : base(message)
    { }
}