// <copyright file="ErrorExtensions.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Api
{
    using System;
    using System.Linq;
    using FluentErrors.Api.Models;
    using FluentErrors.Errors;
    using FluentErrors.Validation;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Error handling extensions.
    /// </summary>
    public static class ErrorExtensions
    {
        /// <summary>
        /// Maps an error to a suggested http outcome.
        /// </summary>
        /// <param name="ex">The error.</param>
        /// <returns>The outcome.</returns>
        public static HttpErrorOutcome ToOutcome(this Exception ex)
        {
            var errorCode = (ex ?? throw new ArgumentNullException(nameof(ex))).ToErrorCode();
            var errorMessage = errorCode == 500 ? "An unexpected error occurred" : ex.Message;
            var invalidItems = ex is ValidatingException valEx ? valEx.InvalidItems : null;

            return new HttpErrorOutcome(
                errorCode,
                new HttpErrorBody(ex.GetType().Name, errorMessage, invalidItems));
        }

        /// <summary>
        /// Maps framework validation failures to a list of invalid items.
        /// </summary>
        /// <param name="state">The state containing the raw errors.</param>
        /// <returns>A mapped array.</returns>
        public static InvalidItem[] ToItems(this ModelStateDictionary state)
            => state.Select(e => new InvalidItem(
                e.Key,
                string.Join(", ", e.Value.Errors.Select(m => m.ErrorMessage)),
                e.Value.RawValue)).ToArray();

        /// <summary>
        /// Maps exceptions to http error codes.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>An http error code.</returns>
        public static int ToErrorCode(this Exception ex) => ex switch
        {
            StaticValidationException _ => 400,
            AuthorisationException _ => 403,
            ResourceMissingException _ => 404,
            ServiceOrchestrationException _ => 422,
            _ => 500,
        };
    }
}