using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DataAccess;
using Models.DTO;
using Repositories.IRepository;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseClassController : ControllerBase
    {
        private readonly IBaseClassRepository _baseC;
        public BaseClassController(IBaseClassRepository baseC)
        {
            _baseC = baseC;
        }

        [HttpGet]
        public List<BaseClass> GetAll()
        {
               return _baseC.GetAll();          
        }
        [HttpPost]
        public void CreateBase(BaseClassDTO name)
        {
            try
            {
                _baseC.CreateBase(name);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
