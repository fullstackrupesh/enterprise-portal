using Microsoft.AspNet.Identity.EntityFramework;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}