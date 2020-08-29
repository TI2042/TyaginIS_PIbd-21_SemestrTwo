using Microsoft.EntityFrameworkCore;
using SecuritySystemDataBaseImplement.Models;
using System;

namespace SecuritySystemDataBaseImplement
{
    public class SecuritySystemDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JQJN4MA\SQLSERVER;
                Initial Catalog=SecuritySystemDB;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Device> Devices { set; get; }

        public virtual DbSet<Equipment> Equipments { set; get; }

        public virtual DbSet<EquipmentDevice> EquipmentDevices { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}
