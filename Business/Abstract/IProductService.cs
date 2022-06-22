using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> Get(string id);
        IResult Create(Product newProduct);
        IResult Update(string id, Product updatedProduct);
        IResult Remove(string id);
        IResult AddCart(string productId, Cart cart);

    }
}
