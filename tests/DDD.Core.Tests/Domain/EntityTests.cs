using Bieber.DDD.Core.Domain;

namespace DDD.Core.Tests.Domain;

public class EntityTests
{
    [Fact]
    public void EntitiesWithSameId_AreEqual()
    {
        var id = Guid.NewGuid();
        var entity1 = new DerivedEntity(id);
        var entity2 = new DerivedEntity(id);

        Assert.Equal(entity1, entity2);
        Assert.True(entity1 == entity2);
    }

    [Fact]
    public void EntitiesWithDifferentIds_AreNotEqual()
    {
        var entity1 = new DerivedEntity(Guid.NewGuid());
        var entity2 = new DerivedEntity(Guid.NewGuid());

        Assert.NotEqual(entity1, entity2);
        Assert.True(entity1 != entity2);
    }

    [Fact]
    public void Equals_WithNull_ReturnsFalse()
    {
        var entity1 = new DerivedEntity(Guid.NewGuid());

        Assert.False(entity1.Equals(null));
    }

    [Fact]
    public void Equals_WithDifferentType_ReturnsFalse()
    {
        var entity1 = new DerivedEntity(Guid.NewGuid());
        var otherType = new OtherType();

        Assert.False(entity1.Equals(otherType));
    }

    [Fact]
    public void GetHashCode_ReturnsCorrectHashCode()
    {
        var id = Guid.NewGuid();
        var entity = new DerivedEntity(id);

        var expectedHashCode = id.GetHashCode() * 41;
        Assert.Equal(expectedHashCode, entity.GetHashCode());
    }

    private class DerivedEntity : Entity
    {
        public DerivedEntity(Guid id) : base(id) { }
    }

    private class OtherType { }
}