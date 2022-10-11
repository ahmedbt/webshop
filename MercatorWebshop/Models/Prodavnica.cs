namespace MercatorWebshop.Models
{
    public class Prodavnica
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public ICollection<Artikl> Artikli { get; set; }

        public Prodavnica()
        {

        }
    }
}
