using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DatabaseEntities.DatabaseModel;

namespace DatabaseEntities
{
    public class DataContext : IdentityDbContext<ApplicationAccount>
    {
        public DataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }
    }
}
