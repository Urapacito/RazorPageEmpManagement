using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public partial class Teams
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        // Min 2, max 50 and message if not valid
        [Required(ErrorMessage = "Team Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Team Name must be between 2 and 50 characters")]
        public string TeamName { get; set; } // Added TeamName

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
