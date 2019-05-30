using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 200, MinimumLength = 2, 
                      ErrorMessage = "The name must be at least 2x and no more than 200 characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        public string SurName { get; set; }

        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Birthday is required")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public string Position { get; set; }
    }
}
