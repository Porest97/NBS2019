using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBS2019.Models;
using NBS2019.Models.HockeyContacts;

namespace NBS2019.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NBS2019.Models.Person> Person { get; set; }
        public DbSet<NBS2019.Models.PersonType> PersonType { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.Contact> Contact { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.ContactRaw> ContactRaw { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.AgeCategory> AgeCategory { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.Club> Club { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.District> District { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.Role> Role { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.Season> Season { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.Sport> Sport { get; set; }
        public DbSet<NBS2019.Models.HockeyContacts.Team> Team { get; set; }
    }
}
