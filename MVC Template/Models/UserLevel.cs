namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLevel
    {
        public int UserLevelID { get; set; }

        public int TopicID { get; set; }

        public int UserID { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int DeletedBy { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
