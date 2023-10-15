using consultorio_seguros_api.Entidad;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Contratos
{
    public interface IMAsegurado
    {
        IRespuesta<Asegurado> Guardar(Asegurado asegurado);
        IRespuesta<Asegurado> Modificar(Asegurado asegurado);
        IRespuesta<Asegurado> Eliminar(long id);
        IRespuesta<Asegurado> Consultar(long id);
        IRespuesta<List<Asegurado>> ConsultarTodos();
        IRespuesta<List<Asegurado>> GuardarMasivo(List<Asegurado> lstAsegurados);
    }
}
