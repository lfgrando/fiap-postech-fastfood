using CrossCutting.Exceptions;
using Menu.Domain.Services.DTOs;
using Menu.Infra.Repositories.Entities;
using Menu.Infra.Repositories.Interfaces;
using MongoAdapter;
using MongoAdapter.Contexts.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Menu.Infra.Repositories;

public class MenuMongoRepository : BaseRepository<MenuItemMongoDb>, IMenuMongoRepository
{
    public MenuMongoRepository(IMongoContext mongoContext)
        : base(mongoContext)
    {

    }

    public async Task<IEnumerable<MenuItemMongoDb>> GetAllAsync(MenuItemFilter filter, CancellationToken cancellationToken)
    {
        var builder = Builders<MenuItemMongoDb>.Filter;
        var filters = new List<FilterDefinition<MenuItemMongoDb>>
        {
            builder.Eq(e => e.IsDeleted, false),
            builder.Eq(e => e.IsActive, true)
        };

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            filters.Add(builder.Regex(e => e.Name, new BsonRegularExpression(filter.Name, "i")));
        }

        if (filter.Category is not null)
        {
            filters.Add(builder.Eq(e => e.Category, filter.Category.Value));
        }

        var finalFilter = builder.And(filters);

        var query = _collection.Find(finalFilter)
                               .Skip(filter.Skip > 0 ? filter.Skip : 0)
                               .Limit(filter.Limit > 0 ? filter.Limit : 0);

        var cursor = await query.ToCursorAsync(cancellationToken);
        return cursor.ToEnumerable(cancellationToken: cancellationToken);
    }

    public async Task<MenuItemMongoDb?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<MenuItemMongoDb>.Filter.Eq(e => e.Id, id);

        var menuItem = await _collection
                                .Find(filter)
                                .FirstOrDefaultAsync(cancellationToken);

        return menuItem;
    }

    public async Task<MenuItemMongoDb> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var filter = Builders<MenuItemMongoDb>.Filter.Eq(e => e.Name, name);

        var menuItem = await _collection
                                .Find(filter)
                                .FirstOrDefaultAsync(cancellationToken);

        return menuItem;
    }

    public async Task<MenuItemMongoDb> InsertOneAsync(MenuItemMongoDb menuItem, CancellationToken cancellationToken)
    {
        var options = new InsertOneOptions();

        try
        {
            await _collection.InsertOneAsync(menuItem, options, cancellationToken);
        }
        catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            throw new DuplicateItemException($"Menu item with name '{menuItem.Name}' already exists.");
        }

        return menuItem;
    }

    public async Task<bool> SoftDeleteAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<MenuItemMongoDb>.Filter.Eq(e => e.Id, id);
        var update = Builders<MenuItemMongoDb>.Update
                                                  .Set(e => e.IsActive, false)
                                                  .Set(e => e.IsDeleted, true);

        var result = await _collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        return result.ModifiedCount > 0;
    }

    public async Task UpdateAsync(string id, MenuItemMongoDb menuItem, CancellationToken cancellationToken)
    {
        var filter = Builders<MenuItemMongoDb>.Filter.Eq(e => e.Id, id);
        var update = Builders<MenuItemMongoDb>.Update
            .Set(e => e.Name, menuItem.Name)
            .Set(e => e.Price, menuItem.Price)
            .Set(e => e.Category, menuItem.Category)
            .Set(e => e.Description, menuItem.Description)
            .Set(e => e.IsActive, menuItem.IsActive);

        await _collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }
}