using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Ürünler
    {
        [Key]
        public int UrunId { get; set; }
       [Column(TypeName ="Varchar")]
       [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlışFiyat { get; set; }
        public decimal SatışFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
       public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

       
        public ICollection<SatışHareket>  SatışHarekets { get; set; }

    }
}