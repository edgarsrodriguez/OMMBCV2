namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProblemAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProblemAnswerID { get; set; }

        public int ProblemID { get; set; }

        public int StudentID { get; set; }

        [Required]
        public string Answer { get; set; }

        public int Attempt { get; set; }

        public int? TutorID { get; set; }

        public int? Score { get; set; }
    }
}
