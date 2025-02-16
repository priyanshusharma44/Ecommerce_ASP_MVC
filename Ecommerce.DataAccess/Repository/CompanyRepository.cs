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
    public class CompanyRepository :  Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Company obj)
        {
            _db.Companys.Update(obj); // Use the Update method for updating existing entries
        }

    }
}
