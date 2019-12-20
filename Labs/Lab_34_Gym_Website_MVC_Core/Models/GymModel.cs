namespace Lab_34_Gym_Website_MVC_Core
{
    using System;

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class GymModel : DbContext
    {

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkoutLog> WorkoutLogs { get; set; }



        public GymModel(DbContextOptions<GymModel> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // FLUENT API
            builder.Entity<Category>().Property(c => c.CategoryName).IsRequired();
            builder.Entity<Exercise>().Property(e => e.ExerciseName).IsRequired();
            builder.Entity<Category>().HasMany(c => c.Exercises).WithOne(e => e.Category);

       
        }
    }
}
