using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace consultorio_seguros_api.Entidad
{

    public class EntidadBase<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }

        public bool Estado { get; set; }

        public DateTimeOffset Fecha { get; set; }

        protected EntidadBase()
        {
            Estado = true;
            Fecha = DateTimeOffset.Now;
        }
    }
}
