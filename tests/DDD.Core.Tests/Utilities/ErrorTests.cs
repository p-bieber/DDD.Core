using Bieber.DDD.Core.Utilities;

namespace DDD.Core.Tests.Utilities;
public class ErrorTests
{
    [Fact]
    public void StaticErrors_AreInitializedCorrectly()
    {
        Assert.Equal(string.Empty, Error.None.Code);
        Assert.Equal(string.Empty, Error.None.Message);
        Assert.Equal(ErrorType.Failure, Error.None.Type);

        Assert.Equal("General.Null", Error.NullValue.Code);
        Assert.Equal("Null value was provided", Error.NullValue.Message);
        Assert.Equal(ErrorType.Failure, Error.NullValue.Type);
    }

    [Fact]
    public void FailureMethod_CreatesErrorWithCorrectType()
    {
        var error = Error.Failure("FailureCode", "FailureMessage");

        Assert.Equal("FailureCode", error.Code);
        Assert.Equal("FailureMessage", error.Message);
        Assert.Equal(ErrorType.Failure, error.Type);
    }

    [Fact]
    public void NotFoundMethod_CreatesErrorWithCorrectType()
    {
        var error = Error.NotFound("NotFoundCode", "NotFoundMessage");

        Assert.Equal("NotFoundCode", error.Code);
        Assert.Equal("NotFoundMessage", error.Message);
        Assert.Equal(ErrorType.NotFound, error.Type);
    }

    [Fact]
    public void ProblemMethod_CreatesErrorWithCorrectType()
    {
        var error = Error.Problem("ProblemCode", "ProblemMessage");

        Assert.Equal("ProblemCode", error.Code);
        Assert.Equal("ProblemMessage", error.Message);
        Assert.Equal(ErrorType.Problem, error.Type);
    }

    [Fact]
    public void ConflictMethod_CreatesErrorWithCorrectType()
    {
        var error = Error.Conflict("ConflictCode", "ConflictMessage");

        Assert.Equal("ConflictCode", error.Code);
        Assert.Equal("ConflictMessage", error.Message);
        Assert.Equal(ErrorType.Conflict, error.Type);
    }

    [Fact]
    public void Errors_WithSameValues_AreEqual()
    {
        var error1 = new Error("Code", "Message", ErrorType.Failure);
        var error2 = new Error("Code", "Message", ErrorType.Failure);

        Assert.Equal(error1, error2);
        Assert.True(error1.Equals(error2));
    }

    [Fact]
    public void Errors_WithDifferentValues_AreNotEqual()
    {
        var error1 = new Error("Code1", "Message1", ErrorType.Failure);
        var error2 = new Error("Code2", "Message2", ErrorType.Problem);

        Assert.NotEqual(error1, error2);
        Assert.False(error1.Equals(error2));
    }
}