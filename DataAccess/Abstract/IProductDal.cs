
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public interface IProductDal 
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        Product Get(Expression<Func<Product, bool>> filter);
        void Create(Product newProduct);
        void Update(string id, Product updatedProduct);
        void Remove(string id);
        void AddCart(string productId, Cart cart);
    }
}
