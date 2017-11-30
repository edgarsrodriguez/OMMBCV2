namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProblemSolution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProblemSolutionID { get; set; }

        public int ProblemID { get; set; }

        [Required]
        public string Solution { get; set; }
    }
}
