using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICartService
    {
        IDataResult<List<Cart>> GetAll();
       /* IDataResult<Cart> Get(string id);*/
        IResult Create(Cart newCart);
        IResult Update(string id, Cart updatedCart);
        IResult Remove(string id);

      

    }
}
