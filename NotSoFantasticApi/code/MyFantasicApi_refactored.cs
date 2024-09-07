
namespace FantasticApi;

public class MyFantasticApi_refactored
{
    private readonly IAmAFantasticDbContext _db;
    private readonly IAmAFantasticCache _cache;

    public MyFantasticApi_refactored(IAmAFantasticDbContext db, IAmAFantasticCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public ResponseDTO DoSomethingFantastic(InputDTO inputData)
    {
        new FantasticValidator().Validate(inputData);
        // do something else fantastic

        if (new CacheRepo(_cache).FantasticCacheInput(inputData))
        {
            return new ResponseDTO(true);
        }

        throw new TestException();
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
