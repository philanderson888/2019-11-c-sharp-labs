namespace Lab_34_Gym_Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
      
        public Category()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
