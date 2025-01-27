using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ecommerce.DataAccess.Repository.IRepository/IUnitOfWork.cs
namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; } // Changed to IProductRepository
        void Save();
    }
}




