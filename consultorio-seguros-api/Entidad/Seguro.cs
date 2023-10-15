using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consultorio_seguros_api.Entidad
{
    [Table("Seguro")]
    public class Seguro : EntidadBase<long>
    {
        [Column(TypeName = "varchar(20)")]
        [Required]
        public string? Codigo { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string? Nombre { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [Required]
        public decimal? SumaAsegurada { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [Required]
        public decimal? Prima { get; set; }
    }
}
