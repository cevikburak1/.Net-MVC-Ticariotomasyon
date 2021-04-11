using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; } 
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        public string TakipKodu { get; set; }
      
        public DateTime Tarih { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Acıklama { get; set; }






    }
}