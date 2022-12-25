using Models.DataAccess;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IBaseService
    {
        Task<IEnumerable<BaseClass>> GetAll();
        Task CreateBase(BaseClassDTO baseClass);
    }
}
