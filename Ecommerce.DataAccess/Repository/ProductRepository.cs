using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Ecommerce_ASPDOTNET_MVC.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class ProductRepository :  Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            _db.Products.Update(obj); // Use the Update method for updating existing entries
        }

    }
}
