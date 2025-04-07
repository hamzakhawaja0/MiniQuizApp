using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MiniQuizApp.Models; // import model (Question.cs) so we can refgister it as a table

// This sets up EF core to create a Questions table in your database from your model
namespace MiniQuizApp.Data{ 

    //this class is your custom database connect bridge, inherits from EF cores DbContext class
    public class AppDbContext : DbContext{ 
        // Constructor that takes config options (like connection string)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // This tells EF Core:
        // "Create a table named 'Questions' using this model"
        public DbSet<Question> Questions {get; set;}
    }
}