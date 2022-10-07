// <copyright file="ServiceOrchestrationError.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors
{
    using System;

    /// <summary>
    /// Represents errors occuring in general domain processing.
    /// </summary>
    public class ServiceOrchestrationError : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceOrchestrationError"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ServiceOrchestrationError(string? message)
            : base(message)
        { }
    }
}