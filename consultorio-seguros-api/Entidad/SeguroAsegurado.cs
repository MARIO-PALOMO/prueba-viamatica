using System.ComponentModel.DataAnnotations.Schema;

namespace consultorio_seguros_api.Entidad
{

    [Table("SeguroAsegurado")]
    public class SeguroAsegurado : EntidadBase<long>
    {
        [ForeignKey("Asegurado")]
        public long AseguradoId { get; set; }
        public virtual Asegurado? Asegurado { get; set; }

        [ForeignKey("Seguro")]
        public long SeguroId { get; set; }
        public virtual Seguro? Seguro { get; set; }
    }
}
