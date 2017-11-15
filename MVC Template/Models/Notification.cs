namespace MVC_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NotificationID { get; set; }

        public int StudentID { get; set; }

        public bool Seen { get; set; }

        public bool Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? DeletedBy { get; set; }

        public int? DeletedDate { get; set; }
    }
}
