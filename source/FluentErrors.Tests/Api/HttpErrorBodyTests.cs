// <copyright file="HttpErrorBodyTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

using FluentErrors.Api.Models;

namespace FluentErrors.Tests.Api
{
    public class HttpErrorBodyTests
    {
        [Fact]
        public void Ctor_WithProperties_RetainsValues()
        {
            // Arrange
            const string type = "mytype";
            const string message = "mymessage";

            // Act
            var result = new HttpErrorBody(type, message);

            // Assert
            result.Type.Should().Be(type);
            result.Message.Should().Be(message);
        }
    }
}
