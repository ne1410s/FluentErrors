// <copyright file="HttpErrorOutcomeTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

using FluentErrors.Api.Models;

namespace FluentErrors.Tests.Api
{
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
}
