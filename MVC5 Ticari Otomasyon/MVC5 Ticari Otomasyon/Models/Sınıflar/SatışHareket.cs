using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class SatışHareket
    {
        [Key]
        public int Satışıd { get; set; }
        //ürün
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        
        public int Urunid { get; set; }
        public int Carilerid { get; set; }
        public int Personelid { get; set; }
        public bool Durum { get; set; }
        public virtual Ürünler Ürünler { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
       
    }
}