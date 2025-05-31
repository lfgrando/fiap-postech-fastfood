using MongoAdapter.Contexts.Interfaces;
using MongoAdapter.Entities;
using MongoAdapter.Entities.Interfaces;
using MongoDB.Driver;

namespace MongoAdapter;

public abstract class BaseRepository<TEntity> where TEntity : IMongoEntity
{
    protected readonly IMongoCollection<TEntity> _collection;

    protected BaseRepository(IMongoContext mongoContext)
    {
        _collection = mongoContext.GetCollection<TEntity>();
    }

    protected async Task<PagedResult<TEntity>> GetPagedAsync(
        int page,
        int size,
        FilterDefinition<TEntity> filter,
        CancellationToken cancellationToken)
    {
        var options = new FindOptions<TEntity>
        {
            Skip = (page - 1) * size,
            Limit = size
        };

        var count = await _collection.CountDocumentsAsync(filter);
        var pages = size == 0 ? 0 : (int)Math.Ceiling(count / (double)size);

        var cursor = await _collection.FindAsync(filter, options, cancellationToken);

        var orders = cursor.ToEnumerable(cancellationToken: cancellationToken);

        var pagedResult = new PagedResult<TEntity>
        {
            Items = orders,
            Page = page,
            Size = size,
            TotalCount = count,
            TotalPages = pages
        };

        return pagedResult;
    }
}