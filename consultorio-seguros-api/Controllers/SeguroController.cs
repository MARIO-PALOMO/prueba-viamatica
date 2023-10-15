using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Entidad;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Controllers
{
    [EnableCors]
    [Route("Seguro")]
    [ApiController]
    public class SeguroController : Controller
    {
        private readonly IMSeguro modeloSeguro;
        public SeguroController(IMSeguro modeloSeguro)
        {
            this.modeloSeguro = modeloSeguro;
        }

        [HttpPost]
        [Route("Guardar")]
        public IRespuesta<Seguro> Guardar(Seguro seguro)
        {
            return modeloSeguro.Guardar(seguro);
        }

        [HttpPut]
        [Route("Modificar")]
        public IRespuesta<Seguro> Modificar(Seguro seguro)
        {
            return modeloSeguro.Modificar(seguro);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IRespuesta<Seguro> Eliminar(long id)
        {
            return modeloSeguro.Eliminar(id);
        }

        [HttpGet]
        [Route("Consultar")]
        public IRespuesta<Seguro> Consultar(long id)
        {
            return modeloSeguro.Consultar(id);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public IRespuesta<List<Seguro>> ConsultarTodos()
        {
            return modeloSeguro.ConsultarTodos();
        }
    }
}
