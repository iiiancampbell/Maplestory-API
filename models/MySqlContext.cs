using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace MyApi.Models
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class Job
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "JobName is required")]
        public string JobName { get; set; } = string.Empty;
        public int JobMaxLvl { get; set; }
    }
}
