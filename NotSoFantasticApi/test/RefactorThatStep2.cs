using FantasticApi;
using Moq;
namespace test;

public class RefactorThatStep2
{
    // [Fact]
    public void ShouldValidateTheInput()
    {
        // Arrange
        InputDTO inputData = null;

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, new Mock<IAmAFantasticCache>().Object);

        // Assert
        Assert.Throws<ArgumentNullException>(() => api.DoSomethingFantastic(inputData));
    }

    // [Fact]
    public void ShouldValidateTheInputProperty()
    {
        // Arrange
        var inputData = new InputDTO();

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, new Mock<IAmAFantasticCache>().Object);

        // Assert
        Assert.Throws<ArgumentNullException>(() => api.DoSomethingFantastic(inputData));
    }

    // [Fact(Skip = "This works, after 3 tries")]
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

    // [Fact(Skip = "Make it iterative")]
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

    // [Fact(Skip = "Make it iterative")]
    [Fact]
    public void ShouldReturnFalseWhenCacheIsNotEqualException()
    {
        // Arrange
        var inputData = new InputDTO { FantasticProperty = "fantastic" };
        var cache = new Mock<IAmAFantasticCache>();
        cache.Setup(x => x.Get("fantasticKey")).Returns(new FantasticCacheResult { FantasticProperty = "not fantastic" });

        // Act
        var api = new MyFantasticApi(new Mock<IAmAFantasticDbContext>().Object, cache.Object);

        // Assert
        Assert.Throws<TestException>(() => api.DoSomethingFantastic(inputData));
    }
}

public class CacheRepoTest
{

    [Fact]
    public void ShouldReturnFalseWhenCacheIsNotEqualException()
    {
        // Arrange
        var inputData = new InputDTO { FantasticProperty = "fantastic" };
        var cache = new Mock<IAmAFantasticCache>();
        cache.Setup(x => x.Get("fantasticKey")).Returns(new FantasticCacheResult { FantasticProperty = "not fantastic" });

        // Act
        var api = new CacheRepo(cache.Object);

        // Assert
        Assert.False(api.FantasticCacheInput(inputData));
    }
}