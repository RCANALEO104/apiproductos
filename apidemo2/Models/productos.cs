using System.ComponentModel.DataAnnotations;

namespace apidemo2.Models
{
    public class productos
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Existencias { get; set; }

    }
}
