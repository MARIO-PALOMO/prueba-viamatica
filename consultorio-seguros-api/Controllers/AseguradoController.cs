using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Entidad;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Controllers
{
    [EnableCors]
    [Route("Asegurado")]
    [ApiController]
    public class AseguradoController : Controller
    {
        private readonly IMAsegurado modeloAsegurado;
        public AseguradoController(IMAsegurado modeloAsegurado)
        {
            this.modeloAsegurado = modeloAsegurado;
        }

        [HttpPost]
        [Route("Guardar")]
        public IRespuesta<Asegurado> Guardar(Asegurado asegurado)
        {
            return modeloAsegurado.Guardar(asegurado);
        }

        [HttpPost]
        [Route("Guardar/Masivo")]
        public IRespuesta<List<Asegurado>> GuardarMasivo(List<Asegurado> lstAsegurados)
        {
            return modeloAsegurado.GuardarMasivo(lstAsegurados);
        }

        [HttpPut]
        [Route("Modificar")]
        public IRespuesta<Asegurado> Modificar(Asegurado asegurado)
        {
            return modeloAsegurado.Modificar(asegurado);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IRespuesta<Asegurado> Eliminar(long id)
        {
            return modeloAsegurado.Eliminar(id);
        }

        [HttpGet]
        [Route("Consultar")]
        public IRespuesta<Asegurado> Consultar(long id)
        {
            return modeloAsegurado.Consultar(id);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public IRespuesta<List<Asegurado>> ConsultarTodos()
        {
            return modeloAsegurado.ConsultarTodos();
        }
    }
}
