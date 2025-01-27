using Bieber.DDD.Core.Utilities;

namespace DDD.Core.Tests.Utilities;

public class ValidationErrorTests
{
    [Fact]
    public void ValidationError_IsInitializedCorrectly()
    {
        var errors = new[]
        {
                Error.Failure("Code1", "Message1"),
                Error.Failure("Code2", "Message2")
            };

        var validationError = new ValidationError(errors);

        Assert.Equal("General.Validation", validationError.Code);
        Assert.Equal("One or more validation errors occurred", validationError.Message);
        Assert.Equal(ErrorType.Validation, validationError.Type);
        Assert.Equal(errors, validationError.Errors);
    }

    [Fact]
    public void FromResults_CreatesValidationErrorWithCorrectErrors()
    {
        var results = new[]
        {
                Result.Failure(Error.Failure("Code1", "Message1")),
                Result.Success(),
                Result.Failure(Error.Failure("Code2", "Message2"))
            };

        var validationError = ValidationError.FromResults(results);

        var expectedErrors = new[]
        {
                Error.Failure("Code1", "Message1"),
                Error.Failure("Code2", "Message2")
            };

        Assert.Equal(expectedErrors, validationError.Errors);
    }
}

