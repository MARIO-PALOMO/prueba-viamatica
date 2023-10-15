using consultorio_seguros_api.Contexto;
using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Entidad;
using Microsoft.EntityFrameworkCore;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Modelo
{
    public class MSeguro: IMSeguro
    {
        private readonly svrlogsContext dbContext;
        public MSeguro(svrlogsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRespuesta<Seguro> Guardar(Seguro seguro)
        {
            var resultado = new IRespuesta<Seguro>();
            try
            {
                var datos = dbContext.Set<Seguro>();
                datos.Add(seguro);
                dbContext.SaveChanges();

                resultado.Codigo = 200;
                resultado.Datos = seguro;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al guardar Seguro: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<Seguro> Modificar(Seguro seguro)
        {
            var resultado = new IRespuesta<Seguro>();
            try
            {
                var consulta = dbContext.Seguro.Where(x => x.Id.Equals(seguro.Id)).FirstOrDefault();

                if (consulta != null)
                {

                    seguro.Id = consulta.Id;
                    consulta.Codigo = seguro.Codigo;
                    consulta.Nombre = seguro.Nombre;
                    consulta.SumaAsegurada = seguro.SumaAsegurada;
                    consulta.Prima = seguro.Prima;
                    dbContext.SaveChanges();

                    resultado.Codigo = 200;
                    resultado.Datos = seguro;
                    resultado.Mensaje = "Éxito";
                }
                else
                {
                    resultado.Codigo = 500;
                    resultado.Datos = null;
                    resultado.Mensaje = "No existe el seguro que intenta modificar";
                }

               
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al modificar Seguro: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<Seguro> Eliminar(long id)
        {
            var resultado = new IRespuesta<Seguro>();
            try
            {
                var consulta = dbContext.Seguro.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (consulta != null)
                {
                    dbContext.Entry(consulta).State = EntityState.Deleted;
                    dbContext.SaveChanges();

                    resultado.Codigo = 200;
                    resultado.Datos = null;
                    resultado.Mensaje = "Éxito";
                }
                else
                {
                    resultado.Codigo = 500;
                    resultado.Datos = null;
                    resultado.Mensaje = "No existe el seguro que intenta eliminar";
                }


            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al eliminar Seguro: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<Seguro> Consultar(long id)
        {
            var resultado = new IRespuesta<Seguro>();
            try
            {
                var consulta = dbContext.Seguro.Where(x => x.Id.Equals(id)).FirstOrDefault();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar Seguro: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<List<Seguro>> ConsultarTodos()
        {
            var resultado = new IRespuesta<List<Seguro>>();
            try
            {
                var consulta = dbContext.Seguro.ToList();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar Seguro: " + ex.Message.ToString();
            }

            return resultado;
        }
    }
}
