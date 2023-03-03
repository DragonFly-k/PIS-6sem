using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using l4.Models;

namespace l4.Db
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("PhoneBook") { }
        public DbSet<Contact> Contacts { get; set; }

    }
}