using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Data.SQLite;

namespace ToDo
{
    class ItemContext : DbContext
    {
        //this property corresponds to the table in our database
        public DbSet<ToDoItem> ToDoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //get the directory the code is being executed from
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            //get the directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            //add 'books.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "todo.db");

            //to check what the path of the file ism uncomment the file below
            //Console.WriteLine("using database file: " + DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}