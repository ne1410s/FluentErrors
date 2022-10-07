// <copyright file="StaticValidationError.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors
{
    using FluentErrors.Validation;

    /// <summary>
    /// Represents errors occuring during static validation.
    /// </summary>
    public class StaticValidationError : ValidationError
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StaticValidationError"/>
        /// class.
        /// </summary>
        /// <param name="invalidItems">Invalid items.</param>
        public StaticValidationError(params InvalidItem[] invalidItems)
            : base(invalidItems)
        { }
    }
}