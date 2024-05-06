using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drones_business.Services
{
    public interface IMedicineService
    {
        bool isCodeExists(string code);
    }
}
