namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int AccountTypeID { get; set; }

        [Required]
        [StringLength(10)]
        public string AccountCode { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
