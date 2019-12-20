namespace Lab_34_Gym_Website_MVC_Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Exercises")]
    public partial class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [StringLength(50)]
        public string ExerciseName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
