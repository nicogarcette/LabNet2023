using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models {
    public class EmployeeViewModel {

        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,15}$", ErrorMessage = "Solo letras, Maximo 15 carateres.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,15}$", ErrorMessage = "Solo letras, Maximo 15 carateres.")]
        public string LastName { get; set; }

    }
}