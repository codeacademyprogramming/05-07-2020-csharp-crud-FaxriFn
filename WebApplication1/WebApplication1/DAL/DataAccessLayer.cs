using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class DataAccessLayer:DbContext
    {
        public DataAccessLayer():base("default")
        {

        }

        public DbSet<Person> People { get; set; }
    }
}