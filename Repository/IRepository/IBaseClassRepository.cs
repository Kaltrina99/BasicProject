using Models.DataAccess;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBaseClassRepository
    {
        List<BaseClass> GetAll();
        void CreateBase(BaseClassDTO baseClass);
    }
}
