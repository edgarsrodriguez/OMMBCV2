namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccountType
    {
        public int AccountTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
