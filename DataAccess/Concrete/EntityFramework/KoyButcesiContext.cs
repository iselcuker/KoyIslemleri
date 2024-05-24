using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class KoyButcesiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-MRP0OC6\SQLEXPRESS; Database=KoyIslemleri;Trusted_Connection=true; TrustServerCertificate=True");
        }

        public DbSet<Ilce> Ilces { get; set; }
        public DbSet<Koy> Koys { get; set; }
        public DbSet<Not> Nots { get; set; }
        public DbSet<Donem> Donems { get; set; }
        public DbSet<Degisiklik> Degisikliks { get; set; }
        public DbSet<EkButceGelir> EkButceGelirs { get; set; }
        public DbSet<EkButceGider> EkButceGiders { get; set; }
        public DbSet<EkButce> EkButces { get; set; }
        public DbSet<GelirKategori> GelirKategoris { get; set; }
        public DbSet<Gelir> Gelirs { get; set; }
        public DbSet<GiderAltKategori> GiderAltKategoris { get; set; }
        public DbSet<GiderKategori> GiderKategoris { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Gorevli> Gorevlis { get; set; }
        public DbSet<IdariIslerAltKategori> IdariIslerAltKategoris { get; set; }
        public DbSet<IdariIslerKategori> IdariIslerKategoris { get; set; }
        public DbSet<TahminiButceGelir> TahminiButceGelirs { get; set; }
        public DbSet<TahminiButceGider> TahminiButceGiders { get; set; }
        public DbSet<TahminiButceIdariIsler> TahminiButceIdariIslers { get; set; }
        public DbSet<TahminiButce> TahminiButces { get; set; }
        public DbSet<Unvan> Unvans { get; set; }



    }
}
