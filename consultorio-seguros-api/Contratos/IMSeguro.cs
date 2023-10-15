using consultorio_seguros_api.Entidad;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Contratos
{
    public interface IMSeguro
    {
        IRespuesta<Seguro> Guardar(Seguro seguro);
        IRespuesta<Seguro> Modificar(Seguro seguro);
        IRespuesta<Seguro> Eliminar(long id);
        IRespuesta<Seguro> Consultar(long id);
        IRespuesta<List<Seguro>> ConsultarTodos();
    }
}
