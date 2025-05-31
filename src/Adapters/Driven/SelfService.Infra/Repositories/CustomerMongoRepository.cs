using MongoAdapter;
using MongoAdapter.Contexts.Interfaces;
using MongoDB.Driver;
using SelfService.Infra.Repositories.Entities;
using SelfService.Infra.Repositories.Interfaces;

namespace SelfService.Infra.Repositories;

public class CustomerMongoRepository : BaseRepository<CustomerMongoDb>, ICustomerMongoRepository
{
    public CustomerMongoRepository(IMongoContext mongoContext)
        : base(mongoContext)
    {

    }

    public async Task<CustomerMongoDb?> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        var filter = Builders<CustomerMongoDb>.Filter.Eq(e => e.CPF, cpf);

        var options = new FindOptions();

        var customer = await _collection.Find(filter, options).FirstOrDefaultAsync(cancellationToken);

        return customer;
    }

    public async Task<CustomerMongoDb?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<CustomerMongoDb>.Filter.Eq(e => e.Id, id);

        var options = new FindOptions();

        var customer = await _collection.Find(filter, options).FirstOrDefaultAsync(cancellationToken);

        return customer;
    }

    public async Task<CustomerMongoDb> InsertOneAsync(CustomerMongoDb customerMongoDb, CancellationToken cancellationToken)
    {
        var options = new InsertOneOptions();

        await _collection.InsertOneAsync(customerMongoDb, options, cancellationToken);

        return customerMongoDb;
    }
}