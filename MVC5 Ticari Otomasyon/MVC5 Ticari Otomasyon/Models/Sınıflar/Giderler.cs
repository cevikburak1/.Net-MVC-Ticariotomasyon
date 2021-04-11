using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Giderler
    {
        [Key]
        public int Giderıd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string GiderAcıklama { get; set; }
        public DateTime GiderTarih { get; set; }
        public decimal tutar { get; set; }
    }
}