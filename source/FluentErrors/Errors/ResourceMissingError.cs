﻿// <copyright file="ResourceMissingError.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors
{
    /// <summary>
    /// Missing resource errors.
    /// </summary>
    public class ResourceMissingError : DataStateError
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ResourceMissingError"/>
        /// class.
        /// </summary>
        /// <param name="message">A description of the exception.</param>
        public ResourceMissingError(string? message = null)
            : base(message ?? "Resource not found")
        { }
    }
}