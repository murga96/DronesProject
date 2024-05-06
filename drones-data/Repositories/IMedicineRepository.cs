using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_data.Repositories
{
    public interface IMedicineRepository
    {
        bool IsCodeExists(string code);
    }
}
