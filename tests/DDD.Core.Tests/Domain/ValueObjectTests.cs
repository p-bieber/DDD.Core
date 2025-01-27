using DDD.Core.Domain;

namespace DDD.Core.Tests.Domain;

public class ValueObjectTests
{
    [Fact]
    public void ValueObjectsWithSameAtomicValues_AreEqual()
    {
        var valueObject1 = new DerivedValueObject(new List<object> { 1, "test" });
        var valueObject2 = new DerivedValueObject(new List<object> { 1, "test" });

        Assert.Equal(valueObject1, valueObject2);
        Assert.True(valueObject1.Equals(valueObject2));
    }

    [Fact]
    public void ValueObjectsWithDifferentAtomicValues_AreNotEqual()
    {
        var valueObject1 = new DerivedValueObject(new List<object> { 1, "test" });
        var valueObject2 = new DerivedValueObject(new List<object> { 2, "different" });

        Assert.NotEqual(valueObject1, valueObject2);
        Assert.False(valueObject1.Equals(valueObject2));
    }

    [Fact]
    public void Equals_WithNull_ReturnsFalse()
    {
        var valueObject = new DerivedValueObject(new List<object> { 1, "test" });

        Assert.False(valueObject.Equals(null));
    }

    [Fact]
    public void GetHashCode_ReturnsCorrectHashCode()
    {
        var values = new List<object> { 1, "test" };
        var valueObject = new DerivedValueObject(values);

        var expectedHashCode = values
            .Aggregate(
                default(int),
                HashCode.Combine);
        Assert.Equal(expectedHashCode, valueObject.GetHashCode());
    }

    private class DerivedValueObject : ValueObject
    {
        private readonly IEnumerable<object> _values;

        public DerivedValueObject(IEnumerable<object> values)
        {
            _values = values;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            return _values;
        }
    }
}
