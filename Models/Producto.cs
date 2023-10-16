using System.ComponentModel.DataAnnotations;

namespace API_Productos.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Escribe tu nombre")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Ingresa la cantidad")]
        public int Cantidad { get; set; }
    }
}
