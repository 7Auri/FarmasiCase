using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _db;

        public AppDbContext(IMongoClient client, string dbName)
        {
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<Product> Products => _db.GetCollection<Product>("products");
        public IMongoCollection<Cart> Carts => _db.GetCollection<Cart>("carts");
    }
}
