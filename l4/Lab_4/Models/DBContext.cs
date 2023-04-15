using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DBContext() : base("DirectoryContext")
        { }
    }
}