﻿using Microsoft.EntityFrameworkCore;

namespace real_estate.Models
{
    public class real_estateDB : DbContext
    {
        public DbSet<Property> Properties { get;  set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<property_status> Status { get; set; }
        public DbSet<property_type> Types { get; set; }
        public DbSet<City> Cities {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=real-estate;Trusted_Connection=True;TrustServerCertificate=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Property
            modelBuilder.Entity<Property>()
                .HasOne(prop => prop.city)
                .WithMany(city => city.properties)
                .HasForeignKey(prop => prop.cityId);
            modelBuilder.Entity<Property>()
                .HasOne(prop => prop.propertyType)
                .WithMany(T => T.properties)
                .HasForeignKey(prop => prop.PropertyTypeId);
            modelBuilder.Entity<Property>()
                .HasOne(prop => prop.propertyStatus)
                .WithMany(S => S.properties)
                .HasForeignKey(prop => prop.PropertyStatusId);
            modelBuilder.Entity<Property>()
                .HasOne(prop => prop.contract)
                .WithOne(C => C.property)
                .HasForeignKey<Contract>(C => C.propertyId);

            modelBuilder.Entity<Property>()
                .HasOne(prop => prop.employee)
                .WithMany(emp => emp.properties)
                .HasForeignKey(prop => prop.EmployeeId);

            


            //Client
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Contracts)
                .WithOne(cont =>cont.client)
                .HasForeignKey(cont => cont.clientId);


            //Contract
            modelBuilder.Entity<Contract>()
                .HasOne(cont => cont.employee)
                .WithMany(emp => emp.contracts)
                .HasForeignKey( cont => cont.employeeId);

            modelBuilder.Entity<Property>(prop =>
            {
                prop.Property(x => x.Price).HasColumnType("money");
            });



            //City
            modelBuilder.Entity<City>()
                .HasMany(C => C.properties)
                .WithOne(prop => prop.city)
                .HasForeignKey(prop => prop.cityId);


        }


    }
}

