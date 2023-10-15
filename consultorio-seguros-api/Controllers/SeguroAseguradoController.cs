using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Entidad;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Controllers
{
    [EnableCors]
    [Route("Seguro/Asegurado")]
    [ApiController]
    public class SeguroAseguradoController : Controller
    {
        private readonly IMSeguroAsegurado modeloSeguroAsegurado;
        public SeguroAseguradoController (IMSeguroAsegurado modeloSeguroAsegurado)
        {
            this.modeloSeguroAsegurado = modeloSeguroAsegurado;
        }

        [HttpPost]
        [Route("Guardar")]
        public IRespuesta<SeguroAsegurado> Guardar(SeguroAsegurado seguroAsegurado)
        {
            return modeloSeguroAsegurado.Guardar(seguroAsegurado);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IRespuesta<SeguroAsegurado> Eliminar(long id)
        {
            return modeloSeguroAsegurado.Eliminar(id);
        }


        [HttpGet]
        [Route("Consultar")]
        public IRespuesta<List<SeguroAsegurado>> ConsultarTodos()
        {
            return modeloSeguroAsegurado.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar/Asegurado")]
        public IRespuesta<List<SeguroAsegurado>> ConsultarCedula(string cedula)
        {
            return modeloSeguroAsegurado.ConsultarCedula(cedula);
        }

        [HttpGet]
        [Route("Consultar/Seguro")]
        public IRespuesta<List<SeguroAsegurado>> ConsultarCodigo(string codigo)
        {
            return modeloSeguroAsegurado.ConsultarCodigo(codigo);
        }
    }
}
