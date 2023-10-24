// <copyright file="HttpErrorBodyTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Tests.Api;

using FluentErrors.Api.Models;

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
