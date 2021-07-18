using MachineApp.DataAccess.Data;
using MachineApp.DataAccess.Repository.IRepository;
using MachineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.DataAccess.Repository
{
    public class ApplicationTypeRepository : Repository<ApplicationType>, IApplicationTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationType applicationType)
        {
            var objFromDb = _db.ApplicationTypes.FirstOrDefault(s => s.Id == applicationType.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = applicationType.Name;

            }

        }
    }
}
