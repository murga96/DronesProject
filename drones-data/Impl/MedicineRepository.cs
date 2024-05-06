using drones_data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_data.Impl
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _appDbContext;
        public MedicineRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        bool IMedicineRepository.IsCodeExists(string code)
        {
            return _appDbContext.Medicines.Any(x => x.Code == code);
        }
    }
}
