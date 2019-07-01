using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBS2019.Models;
using NBS2019.Models.HockeyContacts;
using NBS2019.Models.TestModels;

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
        public DbSet<NBS2019.Models.Company> Company { get; set; }
        public DbSet<NBS2019.Models.Article> Article { get; set; }
        public DbSet<NBS2019.Models.BusinessCentre> BusinessCentre { get; set; }
        public DbSet<NBS2019.Models.Document> Document { get; set; }
        public DbSet<NBS2019.Models.DworkinWiFiSurveyResult> DworkinWiFiSurveyResult { get; set; }
        public DbSet<NBS2019.Models.Invoice> Invoice { get; set; }
        public DbSet<NBS2019.Models.Meeting> Meeting { get; set; }
        public DbSet<NBS2019.Models.MeetingType> MeetingType { get; set; }
        public DbSet<NBS2019.Models.TestModels.Order> Order { get; set; }
        public DbSet<NBS2019.Models.TestModels.OrderPost> OrderPost { get; set; }
        public DbSet<NBS2019.Models.TestModels.PROWorkReport> PROWorkReport { get; set; }
        public DbSet<NBS2019.Models.PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<NBS2019.Models.SupportCase> SupportCase { get; set; }
        public DbSet<NBS2019.Models.TestModels.Salary> Salary { get; set; }
        public DbSet<NBS2019.Models.SupportTicket> SupportTicket { get; set; }
        public DbSet<NBS2019.Models.WorkReport> WorkReport { get; set; }
    }
}
