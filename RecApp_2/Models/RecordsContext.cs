using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecApp_2.Models
{
    public class RecordsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RecordsContext() : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<RecApp_2.Models.Record> Records { get; set; }
        public virtual DbSet<CivilStatus> Civil_Status { get; set; }
    }
}
