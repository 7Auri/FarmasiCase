using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
   public class EfProductDal : IProductDal
    {
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly IConnectionMultiplexer _redisForCart;
        public EfProductDal(IOptions<MongoDbSettings> mongoDbSettings, IConnectionMultiplexer redisForCart)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Product>(mongoDbSettings.Value.ProductsCollectionName);

            _redisForCart = redisForCart;
        }

        


        public void AddCart(string productId,Cart cart)
        {
            var addCart = _productsCollection.Find(x=>x.Id==productId).SingleOrDefault();
            
            var newCart = new Cart()
            {
                Id = cart.Id,
                ProductId = addCart.Id,
                ProductName = addCart.Name,
                ProductPrice = addCart.Price

            };
            var dbase = _redisForCart.GetDatabase();
            var json = JsonSerializer.Serialize(newCart);

            dbase.HashSet("hashForCart", new HashEntry[] { new HashEntry(newCart.Id, json) });
        }






        public void Create(Product newProduct)
        {
            _productsCollection.InsertOne(newProduct);
        }

   
        public Product Get(Expression<Func<Product, bool>> filter)
        {

            return _productsCollection.Find(filter).FirstOrDefault();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productsCollection.Find(_ => true).ToList();
        }

        public void Remove(string id)
        {
            _productsCollection.DeleteOne(x => x.Id == id);
        }

        public void Update(string id, Product updatedProduct)
        {
             _productsCollection.ReplaceOne(x => x.Id == id, updatedProduct);
        }
    }
}
