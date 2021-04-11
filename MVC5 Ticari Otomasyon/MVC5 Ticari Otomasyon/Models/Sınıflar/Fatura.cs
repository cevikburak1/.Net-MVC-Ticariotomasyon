using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSırano { get; set; }
        public DateTime FaturaTarih { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string VergiDairesi { get; set; }
        public string FaturaSaat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public decimal toplamtutar { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}