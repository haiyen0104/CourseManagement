using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GiuaKi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhoaHoc>()
                .HasOne(p => p.LoaiKhoaHoc)
                .WithMany(c => c.KhoaHocs)
                .HasForeignKey(p => p.LoaiKhoaHocId);

            base.OnModelCreating(modelBuilder);
        }

    }
}