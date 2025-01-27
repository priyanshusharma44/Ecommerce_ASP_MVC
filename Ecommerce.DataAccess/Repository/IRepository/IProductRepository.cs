// Ecommerce.DataAccess.Repository.IRepository/IProductRepository.cs
using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        // Remove the GetAll declaration here
    }
}