using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment1_200425207.Models;

namespace AssignmentASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment1_200425207.Models.products> products { get; set; }
        public DbSet<Assignment1_200425207.Models.Equipments> Equipments { get; set; }
    }
}
