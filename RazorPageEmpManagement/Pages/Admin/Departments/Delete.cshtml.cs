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
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentService _departmentService = null;

        public DeleteModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _departmentService.DeleteDepartment(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
