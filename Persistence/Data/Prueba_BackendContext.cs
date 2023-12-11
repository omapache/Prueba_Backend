using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class Prueba_backendContext : DbContext
    {
        public Prueba_backendContext(DbContextOptions options) : base(options) { }

        public DbSet<City> Citys { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<DirPerson> DirPersons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Programation> Programations { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}