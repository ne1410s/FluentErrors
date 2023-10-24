// <copyright file="ErrorExtensionsTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Tests.Api;

using System.Runtime.Serialization;
using FluentErrors.Api;
using FluentErrors.Api.Models;
using FluentErrors.Errors;
using FluentErrors.Validation;

public class ErrorExtensionsTests
{
    [Theory]
    [InlineData(typeof(StaticValidationException), 400)]
    [InlineData(typeof(AuthorisationException), 403)]
    [InlineData(typeof(ResourceMissingException), 404)]
    [InlineData(typeof(DataStateException), 422)]
    [InlineData(typeof(ValidatingException), 422)]
    [InlineData(typeof(ServiceOrchestrationException), 422)]
    [InlineData(typeof(Exception), 500)]
    public void ToErrorCode_VaryingException_ReturnsExpectedCode(Type errorType, int expected)
    {
        // Arrange
        var ex = (Exception)FormatterServices.GetUninitializedObject(errorType);

        // Act
        var actual = ex.ToErrorCode();

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void ToOutcome_GenericException_ConcealsOriginalMessage()
    {
        // Arrange
        var ex = new Exception("secret corporate stuff");
        var expectedBody = new HttpErrorBody(ex.GetType().Name, "An unexpected error occurred");
        var expected = new HttpErrorOutcome(500, expectedBody);

        // Act
        var actual = ex.ToOutcome();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ToOutcome_SupportedError_RelaysOriginalMessage()
    {
        // Arrange
        var ex = new DataStateException("innocuous stuff");
        var expectedBody = new HttpErrorBody(ex.GetType().Name, ex.Message);
        var expected = new HttpErrorOutcome(422, expectedBody);

        // Act
        var actual = ex.ToOutcome();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ToOutcome_ValidationError_ContainsModelData()
    {
        // Arrange
        var errors = new[]
        {
            new InvalidItem("MyProp", "no good", 3),
        };
        var ex = new StaticValidationException(errors);
        var expectedBody = new HttpErrorBody(ex.GetType().Name, ex.Message, errors);
        var expected = new HttpErrorOutcome(400, expectedBody);

        // Act
        var actual = ex.ToOutcome();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ToOutcome_NullException_ThrowsException()
    {
        // Arrange
        var nullException = (DataStateException)null!;

        // Act
        var act = nullException.ToOutcome;

        // Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }
}
