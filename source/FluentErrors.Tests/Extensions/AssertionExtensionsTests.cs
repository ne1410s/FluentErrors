// <copyright file="AssertionExtensionsTests.cs" company="ne1410s">
// Copyright (c) ne1410s. All rights reserved.
// </copyright>

namespace FluentErrors.Tests.Extensions;

using System.Globalization;
using FluentErrors.Errors;
using FluentErrors.Extensions;
using FluentErrors.Tests.Validation;
using FluentErrors.Validation;

/// <summary>
/// Tests for the <see cref="AssertionExtensions"/> class.
/// </summary>
public class AssertionExtensionsTests
{
    [Fact]
    public void MustBePopulated_IsPopulated_DoesNotThrow()
    {
        // Arrange
        const string testObj = "hello";

        // Act
        var act = () => testObj.MustBePopulated();

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBePopulated_NotPopulated_ThrowsDataStateError()
    {
        // Arrange
        const string testObj = null!;

        // Act
        var act = () => testObj.MustBePopulated();

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustBePopulated_NotPopulatedAndHasMessage_ExceptionContainsMessage()
    {
        // Arrange
        const string testObj = null!;
        const string message = "no greetings allowed!";

        // Act
        var act = () => testObj.MustBePopulated(message);

        // Assert
        act.ShouldThrow<Exception>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustBePopulated_NotPopulatedButExempt_DoesNotThrow()
    {
        // Arrange
        const string testObj = null!;

        // Act
        var act = () => testObj.MustBePopulated(unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBePopulated_PopulatedAndExempt_DoesNotThrow()
    {
        // Arrange
        const string testObj = "hello";

        // Act
        var act = () => testObj.MustBePopulated(unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBePopulated_DefaultValueType_ThrowsDataStateError()
    {
        // Arrange
        const int testObj = default;

        // Act
        Action act = () => testObj.MustBePopulated();

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustBePopulated_NullableValueTypeWithValueDefault_DoesNotThrow()
    {
        // Arrange
        int? testObj = default(int);

        // Act
        var act = () => testObj.MustBePopulated();

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBeUnpopulated_IsPopulated_ThrowsDataStateError()
    {
        // Arrange
        const string testObj = "hello";

        // Act
        var act = () => testObj.MustBeUnpopulated();

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustBeUnpopulated_IsPopulatedAndHasMessage_ExceptionContainsMessage()
    {
        // Arrange
        const string testObj = "hello";
        const string message = "no greetings allowed!";

        // Act
        var act = () => testObj.MustBeUnpopulated(message);

        // Assert
        act.ShouldThrow<Exception>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustBeUnpopulated_IsPopulatedButExempt_DoesNotThrow()
    {
        // Arrange
        const string testObj = "hello";

        // Act
        var act = () => testObj.MustBeUnpopulated(unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBeUnpopulated_NotPopulated_DoesNotThrow()
    {
        // Arrange
        const string testObj = null!;

        // Act
        var act = () => testObj.MustBeUnpopulated();

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBeUnpopulated_NotPopulatedAndExempt_DoesNotThrow()
    {
        // Arrange
        const string testObj = null!;

        // Act
        var act = () => testObj.MustBeUnpopulated(unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustSerializeAs_MatchingObjects_DoesNotThrow()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "123" };

        // Act
        var act = () => object1.MustSerializeAs(object2);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustSerializeAs_NotMatchingObjects_ThrowsDataStateError()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "124" };

        // Act
        var act = () => object1.MustSerializeAs(object2);

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustSerializeAs_NotMatchingObjectsWithMessage_ExceptionContainsMessage()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "124" };
        const string message = "No match, bro";

        // Act
        var act = () => object1.MustSerializeAs(object2, message);

        // Assert
        act.ShouldThrow<DataStateException>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustSerializeAs_NotMatchingObjectsButExempt_DoesNotThrow()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "124" };

        // Act
        var act = () => object1.MustSerializeAs(object2, unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustNotSerializeAs_NotMatchingObjects_DoesNotThrow()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "124" };

        // Act
        var act = () => object1.MustNotSerializeAs(object2);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustNotSerializeAs_MatchingObjects_ThrowsDataStateError()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "123" };

        // Act
        var act = () => object1.MustNotSerializeAs(object2);

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustNotSerializeAs_MatchingObjectsWithMessage_ExceptionContainsMessage()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "123" };
        const string message = "No match, bro";

        // Act
        var act = () => object1.MustNotSerializeAs(object2, message);

        // Assert
        act.ShouldThrow<DataStateException>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustNotSerializeAs_MatchingObjectsButExempt_DoesNotThrow()
    {
        // Arrange
        var object1 = new { Test = "123" };
        var object2 = new { Test = "123" };

        // Act
        var act = () => object1.MustNotSerializeAs(object2, unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBe_AreEqual_DoesNotThrow()
    {
        // Arrange
        const int value = 2;

        // Act
        var act = () => value.MustBe(1 + 1);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBe_NotEqual_ThrowsDataStateError()
    {
        // Arrange
        const int value = 5;

        // Act
        Action act = () => value.MustBe(2 + 2);

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustBe_NotEqualWithMessage_ExceptionContainsMessage()
    {
        // Arrange
        const int value = 5;
        const string message = "no dice";

        // Act
        Action act = () => value.MustBe(2 + 2, message);

        // Assert
        act.ShouldThrow<DataStateException>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustBe_NotEqualButExempt_DoesNotThrow()
    {
        // Arrange
        const int value = 5;

        // Act
        var act = () => value.MustBe(2 + 2, unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustNotBe_NotEqual_DoesNotThrow()
    {
        // Arrange
        var date1 = new DateTime(1985, 10, 26, 0, 0, 0, DateTimeKind.Utc);
        var date2 = DateTime.Parse("1985/10/26", CultureInfo.InvariantCulture).Date.AddHours(1);

        // Act
        var act = () => date1.MustNotBe(date2);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustNotBe_AreEqual_ThrowsDataStateError()
    {
        // Arrange
        var date1 = new DateTime(1985, 10, 26, 0, 0, 0, DateTimeKind.Utc);
        var date2 = DateTime.Parse("1985/10/26", CultureInfo.InvariantCulture).Date.AddHours(0);

        // Act
        Action act = () => date1.MustNotBe(date2);

        // Assert
        _ = act.ShouldThrow<DataStateException>();
    }

    [Fact]
    public void MustNotBe_AreEqualWithMessage_ExceptionContainsMessage()
    {
        // Arrange
        var date1 = new DateTime(1985, 10, 26, 0, 0, 0, DateTimeKind.Utc);
        var date2 = new DateTime(1985, 10, 26, 0, 0, 0, DateTimeKind.Utc);
        const string message = "same, bro";

        // Act
        Action act = () => date1.MustNotBe(date2, message);

        // Assert
        act.ShouldThrow<DataStateException>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustNotBe_AreEqualButExempt_DoesNotThrow()
    {
        // Arrange
        var date1 = new DateTime(1985, 10, 26, 0, 0, 0, DateTimeKind.Utc);
        var date2 = new DateTime(1985, 10, 26, 0, 0, 0, DateTimeKind.Utc);

        // Act
        var act = () => date1.MustNotBe(date2, unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustAdhereTo_IsValid_DoesNotThrow()
    {
        // Arrange
        var model = new TestModel();
        var mockValidator = new Mock<IItemValidator<TestModel>>();

        // Act
        var act = () => model.MustAdhereTo(mockValidator.Object);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustAdhereTo_NotValid_ThrowsExpectedError()
    {
        // Arrange
        var model = new TestModel();
        var mockValidator = new Mock<IItemValidator<TestModel>>();
        _ = mockValidator
            .Setup(m => m.AssertValid(It.IsAny<TestModel>()))
            .Throws(new ValidatingException());

        // Act
        var act = () => model.MustAdhereTo(mockValidator.Object);

        // Assert
        act.ShouldThrow<ValidatingException>()
            .Message.ShouldBe("Invalid instance received.");
    }

    [Fact]
    public void MustAdhereTo_NotValidButExempt_DoesNotThrow()
    {
        // Arrange
        var model = new TestModel();
        var mockValidator = new Mock<IItemValidator<TestModel>>();
        _ = mockValidator
            .Setup(m => m.AssertValid(It.IsAny<TestModel>()))
            .Throws(new ValidatingException());

        // Act
        var act = () => model.MustAdhereTo(mockValidator.Object, () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustAdhereTo_NullValidator_ThrowsException()
    {
        // Arrange
        var model = new TestModel();

        // Act
        var act = () => model.MustAdhereTo(null!);

        // Assert
        _ = act.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void MustExist_IsNull_ThrowsResourceMissingError()
    {
        // Arrange
        TestModel testObj = null!;

        // Act
        var act = () => testObj.MustExist();

        // Assert
        _ = act.ShouldThrow<ResourceMissingException>();
    }

    [Fact]
    public void MustExist_IsDefault_ThrowsResourceMissingError()
    {
        // Arrange
        const int testVal = 0;

        // Act
        Action act = () => testVal.MustExist();

        // Assert
        _ = act.ShouldThrow<ResourceMissingException>();
    }

    [Fact]
    public void MustExist_NotDefault_DoesNotThrow()
    {
        // Arrange
        TestModel testObj = new();

        // Act
        var act = () => testObj.MustExist();

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustExist_IsDefaultNoMessage_ExceptionContainsDefaultMessage()
    {
        // Arrange
        bool? testObj = null;

        // Act
        Action act = () => testObj.MustExist();

        // Assert
        act.ShouldThrow<Exception>().Message.ShouldBe("Resource not found");
    }

    [Fact]
    public void MustExist_IsDefaultWithMessage_ExceptionContainsMessage()
    {
        // Arrange
        bool? testObj = null;
        const string message = "just no";

        // Act
        Action act = () => testObj.MustExist(message);

        // Assert
        act.ShouldThrow<Exception>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustExist_IsDefaultButExempt_DoesNotThrow()
    {
        // Arrange
        bool? testObj = null;

        // Act
        var act = () => testObj.MustExist(unless: () => true);

        // Assert
        _ = act.ShouldNotThrow();
    }

    [Fact]
    public void MustBeAllowed_NotAllowed_ThrowsAuthorisationError()
    {
        // Arrange
        const bool isAllowed = false;

        // Act
        var act = () => isAllowed.MustBeAllowed();

        // Assert
        _ = act.ShouldThrow<AuthorisationException>();
    }

    [Fact]
    public void MustBeAllowed_NotAllowedNoMessage_ExceptionContainsDefaultMessage()
    {
        // Arrange
        const bool isAllowed = false;

        // Act
        var act = () => isAllowed.MustBeAllowed();

        // Assert
        act.ShouldThrow<Exception>().Message.ShouldBe("Forbidden");
    }

    [Fact]
    public void MustBeAllowed_NotAllowedWithMessage_ExceptionContainsMessage()
    {
        // Arrange
        const bool isAllowed = false;
        const string message = "errr..";

        // Act
        var act = () => isAllowed.MustBeAllowed(message);

        // Assert
        act.ShouldThrow<Exception>().Message.ShouldBe(message);
    }

    [Fact]
    public void MustBeAllowed_NotAllowedButExempt_DoesNotThrow()
    {
        // Arrange
        const bool isAllowed = false;

        // Act
        var act = () => isAllowed.MustBeAllowed(unless: () => true);

        // Assert
        act.ShouldNotThrow();
    }

    [Fact]
    public void MustBeAllowed_IsAllowed_DoesNotThrow()
    {
        // Arrange
        const bool isAllowed = true;

        // Act
        var act = () => isAllowed.MustBeAllowed();

        // Assert
        act.ShouldNotThrow();
    }
}
