// <copyright file="AuthorisationError.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors
{
    /// <summary>
    /// Authorisation errors.
    /// </summary>
    public class AuthorisationError : ServiceOrchestrationError
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AuthorisationError"/> class.
        /// </summary>
        /// <param name="message">A description of the exception.</param>
        public AuthorisationError(string? message = null)
            : base(message ?? "Forbidden")
        { }
    }
}