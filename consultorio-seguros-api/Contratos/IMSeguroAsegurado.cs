using consultorio_seguros_api.Entidad;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Contratos
{
    public interface IMSeguroAsegurado
    {
        IRespuesta<SeguroAsegurado> Guardar(SeguroAsegurado seguroAsegurado);
        IRespuesta<SeguroAsegurado> Eliminar(long id);
        IRespuesta<List<SeguroAsegurado>> ConsultarTodos();
        IRespuesta<List<SeguroAsegurado>> ConsultarCedula(string cedula);
        IRespuesta<List<SeguroAsegurado>> ConsultarCodigo(string codigo);
    }
}
