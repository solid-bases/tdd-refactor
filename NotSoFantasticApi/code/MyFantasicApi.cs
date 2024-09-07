
namespace FantasticApi;

public class MyFantasticApi
{
    private readonly IAmAFantasticDbContext _db;
    private readonly IAmAFantasticCache _cache;

    public MyFantasticApi(IAmAFantasticDbContext db, IAmAFantasticCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public ResponseDTO DoSomethingFantastic(InputDTO inputData)
    {
        if (inputData == null)
        {
            throw new ArgumentNullException(nameof(inputData));
        }
        if (inputData.FantasticProperty == null)
        {
            throw new ArgumentNullException(nameof(inputData.FantasticProperty));
        }
        if (false /*other fantastic conditions*/)
        {
            // other fantastic code
        }
        // do something else fantastic

        var fantasticCache = _cache.Get("fantasticKey");
        if (fantasticCache.FantasticProperty == inputData.FantasticProperty)
        {
            return new ResponseDTO(true);
        }

        while (inputData.FantasticList.Any())
        {
            var fantasticItem = inputData.FantasticList.Dequeue();

            // do something fantastic
            var fantasticData = _db.FantasticTable.Where(x => x.FantasticProperty == fantasticItem.Property).ToList();

            // do something else fantastic
            if (_db.FantasticTable.Any(x => x.FantasticProperty != fantasticData[0].FantasticProperty))
            {
                return new ResponseDTO(true);
            }
        }
        return new ResponseDTO(false);
    }

}

public class FantasticValidator
{

    public void Validate(InputDTO inputData)
    {
        if (inputData == null)
        {
            throw new ArgumentNullException(nameof(inputData));
        }
        if (inputData.FantasticProperty == null)
        {
            throw new ArgumentNullException(nameof(inputData.FantasticProperty));
        }
        if (false /*other fantastic conditions*/)
        {
            // other fantastic code
        }
    }
}

public class CacheRepo
{
    private readonly IAmAFantasticCache _cache;

    public CacheRepo(IAmAFantasticCache cache)
    {
        _cache = cache;
    }

    public bool FantasticCacheInput(InputDTO inputData)
    {
        var fantasticCache = _cache.Get("fantasticKey");
        if (fantasticCache.FantasticProperty == inputData.FantasticProperty)
        {
            return true;
        }
        return false;
    }
}


public interface IAmAFantasticCache
{
    FantasticCacheResult Get(string v);
}

public class FantasticCacheResult
{
    public string FantasticProperty { get; set; }
}

public interface IAmAFantasticDbContext
{
    IEnumerable<FantasticTable> FantasticTable { get; }
}

public class FantasticTable
{
    public string FantasticProperty;
}

public class ResponseDTO
{
    private bool _v;

    public ResponseDTO(bool v)
    {
        _v = v;
    }

    public bool Success { get { return _v; } }
}

public class InputDTO
{
    public string FantasticProperty;

    public Queue<FantasticItem> FantasticList { get; set; }
}

public class FantasticItem
{
    public object Property;
}

public class TestException : Exception { }

