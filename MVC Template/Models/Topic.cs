namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicID { get; set; }

        public int AreaID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
