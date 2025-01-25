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
    public class CategoryRepository :  Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Category obj)
        {
            _db.Categories.Update(obj); // Use the Update method for updating existing entries
        }

    }
}
