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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult AddCart(string productId, Cart cart)
        {
            _productDal.AddCart(productId,cart);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IResult Create(Product newProduct)
        {
            _productDal.Create(newProduct);
            return new SuccessResult(Messages.SuccessAdd);
        }

        public IDataResult<Product> Get(string id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.Id == id), Messages.SuccessListed);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.SuccessListed);
        }

        public IResult Remove(string id)
        {
            _productDal.Remove(id);
            return new SuccessResult(Messages.SuccessDelete);
        }

        public IResult Update(string id, Product updatedProduct)
        {
            _productDal.Update(id, updatedProduct);
            return new SuccessResult(Messages.SuccessUpdate);
        }
    }
}
