using drones_business.Services;
using drones_data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_business.Impl
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;
        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }
        bool IMedicineService.isCodeExists(string code)
        {
            return _repository.IsCodeExists(code);
        }
    }
}
