using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.DepartmentService;

namespace RazorPageEmpManagement.Pages.Admin.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly IDepartmentService _departmentService = null;

        public DetailsModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

      public Department Department { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = _departmentService.GetDepartmentById(id.Value);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
