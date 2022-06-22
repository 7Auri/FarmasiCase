using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

     

        public IResult Create(Cart newCart)
        {
            _cartDal.Create(newCart);
            return new SuccessResult(Messages.SuccessAdd);
        }

       /* public IDataResult<Cart> Get(string id)
        {
            return new SuccessDataResult<Cart>(_cartDal.Get(x => x.Id == id), Messages.SuccessListed);
        }*/

        public IDataResult<List<Cart>> GetAll()
        {
            return new SuccessDataResult<List<Cart>>(_cartDal.GetAll(), Messages.SuccessListed);
        }

        public IResult Remove(string id)
        {
            _cartDal.Remove(id);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IResult Update(string id, Cart updatedCart)
        {
            _cartDal.Update(id, updatedCart);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
