using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int CarilId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]

        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Şifre { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatışHareket> SatışHarekets { get; set; }
    }
}