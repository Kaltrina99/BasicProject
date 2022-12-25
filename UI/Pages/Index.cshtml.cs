using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Models.DataAccess;
using Models.DTO;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBaseService _baseService;
        [BindProperty]
        public List<BaseClass> b { get; set; } = new List<BaseClass>();

        public IndexModel(ILogger<IndexModel> logger, IBaseService baseService)
        {
            _logger = logger;
            _baseService=baseService;
        }

        public async Task<ActionResult> OnGet()
        {
            foreach (var user in _baseService.GetAll().Result)
            {
                var b1 = new BaseClass
                {
                    ID = user.ID,
                    Name = user.Name,
                    Active=user.Active,
                };
                b.Add(b1);
            }

            return Page();
        }
      

    }
}
