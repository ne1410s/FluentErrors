// <copyright file="HttpErrorOutcomeTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Tests.Api;

using FluentErrors.Api.Models;

public class HttpErrorOutcomeTests
{
    [Fact]
    public void Ctor_WithProperties_RetainsValues()
    {
        // Arrange
        const int errorCode = 1;
        var errorBody = new HttpErrorBody("mytype", "mymessage");

        // Act
        var result = new HttpErrorOutcome(errorCode, errorBody);

        // Assert
        result.ErrorCode.Should().Be(1);
        result.ErrorBody.Should().BeEquivalentTo(errorBody);
    }
}
