using MachineApp.DataAccess.Data;
using MachineApp.DataAccess.Repository.IRepository;
using MachineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
                objFromDb.Name = product.Name;
                objFromDb.Price = product.Price;
                objFromDb.ShortDesc = product.ShortDesc;
                objFromDb.Description = product.Description;
                objFromDb.CategoryId = product.CategoryId;

                objFromDb.ApplicationTypeId = product.ApplicationTypeId;

            }
        }
    }
}
