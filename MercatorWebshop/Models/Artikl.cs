using System.ComponentModel.DataAnnotations.Schema;

namespace MercatorWebshop.Models
{
    public class Artikl
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
        public int ProdavnicaID { get; set; }
        [ForeignKey("ProdavnicaID")]

        public Prodavnica Prodavnica { get; set; }

        public Artikl()
        {

        }
    }
}
