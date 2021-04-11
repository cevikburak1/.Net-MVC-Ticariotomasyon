using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Yapılcaklar
    {
        [Key]
        public int YapılacakId { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string baslık { get; set; }
     
        

        
    }
}