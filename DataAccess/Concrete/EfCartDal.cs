using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;

namespace DataAccess.Concrete
{
    public class EfCartDal : ICartDal
    {
        private readonly IConnectionMultiplexer _redisForCart;


        public EfCartDal(IConnectionMultiplexer redisForCart)
        {
            _redisForCart = redisForCart;
           
        }
 
        public void Create(Cart cart)
        {
            var newCart = new Cart()
            {
                Id = cart.Id,
                ProductId = cart.ProductId,
                ProductName= cart.ProductName,
                ProductPrice=cart.ProductPrice
                
               
            };
            var dbase = _redisForCart.GetDatabase();
            var json = JsonSerializer.Serialize(newCart);

            dbase.HashSet("hashForCart", new HashEntry[] { new HashEntry(newCart.Id, json) });
        }

       


        public Cart Get(string id)
        {
            var dbase = _redisForCart.GetDatabase();
            var cart = dbase.HashGet("hashForCart", id);

            if (!string.IsNullOrEmpty(cart))
            {
                return JsonSerializer.Deserialize<Cart>(cart);
            }

            return null;
        }

        public List<Cart> GetAll(Expression<Func<Cart, bool>> filter = null)
        {
            var dbase = _redisForCart.GetDatabase();
            var completeSet = dbase.HashGetAll("hashForCart");

            if (completeSet.Length > 0)
            {
                var obj = Array.ConvertAll(completeSet, val => JsonSerializer.Deserialize<Cart>(val.Value)).ToList();
                return obj;
            }

            return null;
        }

        public void Remove(string id)
        {
            var dbase = _redisForCart.GetDatabase();
            dbase.HashDelete("hashForCart", id);
        }

        public Cart Update(string id, Cart updatedCart)
        {
            var dbase = _redisForCart.GetDatabase();
            var cart = dbase.HashGet("hashForCart", id);

            if (!string.IsNullOrEmpty(cart))
            {
                return JsonSerializer.Deserialize<Cart>(cart);
            }

            return null;
        }
    }
}
