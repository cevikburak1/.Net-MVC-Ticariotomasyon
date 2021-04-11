using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_Ticari_Otomasyon.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        public string Gönderici { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Alıcı { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Konu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2200)]
        public string İcerik { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}