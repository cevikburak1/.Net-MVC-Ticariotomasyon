using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string acıklama { get; set; }
        public int Miktar { get; set; }
        public decimal Birim { get; set; }
        public decimal Tutar { get; set; }
        public int Faturaıd { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}