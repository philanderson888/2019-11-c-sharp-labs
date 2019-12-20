namespace Lab_33_MVC_Framework_Entity_Helpdesk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public int? CategoryId { get; set; }

        public bool? IsLiveUser { get; set; }

        public string Test { get; set; }

        public int TestInt { get; set; }

        public int? TestInt2 { get; set; }

        public string NewField { get; set; }
        public string NewField2 { get; set; }

        public virtual Category Category { get; set; }
    }
}
