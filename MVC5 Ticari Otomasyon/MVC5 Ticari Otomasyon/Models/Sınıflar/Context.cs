using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins  { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmens { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Giderler> Giderlers { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatışHareket> SatışHarekets { get; set; }
        public DbSet<Ürünler> Ürünlers { get; set; }
        public DbSet<detay> Detays { get; set; }
        public DbSet<Yapılcaklar> Yapılcaklars { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
    }
}