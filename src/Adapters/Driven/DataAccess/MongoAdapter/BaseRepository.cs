using MongoAdapter.Contexts.Interfaces;
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
}