using FantasticApi;

using Moq;
namespace test;

public class RefactorThatStep1
{
    [Fact]
    public void ShouldValidateTheInput()
    {
        // Arrange
        InputDTO inputData = null;

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, new Mock<IAmAFantasticCache>().Object);

        // Assert
        Assert.Throws<ArgumentNullException>(() => api.DoSomethingFantastic(inputData));
    }

    [Fact]
    public void ShouldValidateTheInputProperty()
    {
        // Arrange
        var inputData = new InputDTO();

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, new Mock<IAmAFantasticCache>().Object);

        // Assert
        Assert.Throws<ArgumentNullException>(() => api.DoSomethingFantastic(inputData));
    }

    [Fact]
    public void ShouldReturnTrueWhenCacheIsEqual()
    {
        // Arrange
        var inputData = new InputDTO { FantasticProperty = "fantastic" };
        var cache = new Mock<IAmAFantasticCache>();
        cache.Setup(x => x.Get("fantasticKey")).Returns(new FantasticCacheResult { FantasticProperty = "fantastic" });

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, cache.Object);
        var result = api.DoSomethingFantastic(inputData);

        // Assert
        Assert.True(result.Success);
    }

    // [Fact]
    public void ShouldReturnFalseWhenCacheIsNotEqual()
    {
        // Arrange
        var inputData = new InputDTO { FantasticProperty = "fantastic" };
        var cache = new Mock<IAmAFantasticCache>();
        cache.Setup(x => x.Get("fantasticKey")).Returns(new FantasticCacheResult { FantasticProperty = "not fantastic" });

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, cache.Object);
        var result = api.DoSomethingFantastic(inputData);

        // Assert
        Assert.False(result.Success);
    }
}