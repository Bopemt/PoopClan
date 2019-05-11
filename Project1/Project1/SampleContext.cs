using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project1
{
    class SampleContext : DbContext
    {
        public SampleContext() : base("CompData")
        { }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PeripheralDevice> PeripheralDevices { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<HDD> HDDs { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
