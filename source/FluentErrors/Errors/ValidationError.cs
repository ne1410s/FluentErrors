// <copyright file="ValidationError.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Errors
{
    using System.Collections.Generic;
    using FluentErrors.Validation;

    /// <summary>
    /// Represents errors occuring during validation.
    /// </summary>
    public class ValidationError : ServiceOrchestrationError
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ValidationError"/>
        /// class.
        /// </summary>
        /// <param name="invalidItems">Invalid items.</param>
        public ValidationError(params InvalidItem[] invalidItems)
            : base("Invalid instance received.")
        {
            this.InvalidItems = invalidItems;
        }

        /// <summary>
        /// Gets the invalid items.
        /// </summary>
        public IList<InvalidItem> InvalidItems { get; }
    }
}