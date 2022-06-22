using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface ICartDal
    {
        List<Cart> GetAll(Expression<Func<Cart, bool>> filter = null);
        Cart Get(string id);
        void Create(Cart newCarts);
        Cart Update(string id, Cart updatedCart);
        void Remove(string id);
  
    }
}
