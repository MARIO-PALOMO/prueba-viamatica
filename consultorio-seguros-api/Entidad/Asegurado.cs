using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consultorio_seguros_api.Entidad
{
    [Table("Asegurado")]
    public class Asegurado : EntidadBase<long>
    {
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string? Cedula { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string? Nombre { get; set; }

        [Column(TypeName = "varchar(2)")]
        [Required]
        public string? Edad { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        public string? Telefono { get; set; }
    }
}
