// <copyright file="HttpAssertionExtensionsTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Tests.Extensions;

using System.Net;
using System.Text;
using FluentErrors.Errors;
using FluentErrors.Extensions;

/// <summary>
/// Tests for the <see cref="HttpAssertionExtensionsTests"/> class.
/// </summary>
public class HttpAssertionExtensionsTests
{
    [Fact]
    public async Task MustBeOk_NullStub_ThrowsError()
    {
        // Arrange
        var stub = (HttpResponseMessage)null!;

        // Act
        var act = () => stub.MustBeOk();

        // Assert
        await act.ShouldThrowAsync<DataStateException>();
    }

    [Fact]
    public async Task MustBeOk_BasicSuccess_ReturnsExpected()
    {
        // Arrange
        using var stub = GetStub(200);

        // Act
        var result = await stub.MustBeOk();

        // Assert
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task MustBeOk_AlsoAllowed_ReturnsExpected()
    {
        // Arrange
        using var stub = GetStub(503);

        // Act
        var result = await stub.MustBeOk(alsoAllowed: [503]);

        // Assert
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task MustBeOk_Disallowed_ThrowsError()
    {
        // Arrange
        const int disallowed = 204;
        using var stub = GetStub(disallowed);
        var expectedMessage = $"Unexpected HTTP response status: {disallowed}";

        // Act
        var act = () => stub.MustBeOk(disallowed: [204]);

        // Assert
        var ex = await act.ShouldThrowAsync<HttpResponseException>();
        ex.Message.ShouldBe(expectedMessage);
    }

    [Fact]
    public async Task MustBeOk_JsonError_ErrorContainsContent()
    {
        // Arrange
        using var stub = GetJsonStub(500);

        // Act
        var act = () => stub.MustBeOk();

        // Assert
        (await act.ShouldThrowAsync<HttpResponseException>())
            .Content!.ShouldContain("test");
    }

    [Fact]
    public async Task MustBeOk_NoContentError_ErrorContentEmpty()
    {
        // Arrange
        using var stub = GetStub(500);
        stub.Content = null;

        // Act
        var act = () => stub.MustBeOk();

        // Assert
        (await act.ShouldThrowAsync<HttpResponseException>())
            .Content.ShouldBeNullOrEmpty();
    }

    [Fact]
    public async Task MustBeOk_BadCodeButExempt_DoesNotThrow()
    {
        // Arrange
        using var stub = GetStub(500);

        // Act
        var act = () => stub.MustBeOk(unless: () => true);

        // Assert
        await act.ShouldNotThrowAsync();
    }

    private static HttpResponseMessage GetStub(int code) => new((HttpStatusCode)code)
    {
        Content = new StringContent("Nope!"),
    };

    private static HttpResponseMessage GetJsonStub(int code)
    {
        var retVal = new HttpResponseMessage((HttpStatusCode)code);
        retVal.Content = new StringContent("{\"test\":true}", Encoding.UTF8, "application/json");
        return retVal;
    }
}
