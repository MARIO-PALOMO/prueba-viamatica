using consultorio_seguros_api.Contexto;
using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Entidad;
using Microsoft.EntityFrameworkCore;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Modelo
{
    public class MAsegurado : IMAsegurado
    {
        private readonly svrlogsContext dbContext;
        public MAsegurado(svrlogsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRespuesta<Asegurado> Guardar(Asegurado asegurado)
        {
            var resultado = new IRespuesta<Asegurado>();
            try
            {
                var datos = dbContext.Set<Asegurado>();
                datos.Add(asegurado);
                dbContext.SaveChanges();

                resultado.Codigo = 200;
                resultado.Datos = asegurado;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al guardar Asegurado: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<List<Asegurado>> GuardarMasivo(List<Asegurado> lstAsegurados)
        {
            var resultado = new IRespuesta<List<Asegurado>>();
            try
            {
                dbContext.Asegurado.AddRange(lstAsegurados);
                dbContext.SaveChanges();

                resultado.Codigo = 200;
                resultado.Datos = lstAsegurados;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al guardar Asegurados: " + ex.Message.ToString();
            }

            return resultado;
        }


        public IRespuesta<Asegurado> Modificar(Asegurado asegurado)
        {
            var resultado = new IRespuesta<Asegurado>();
            try
            {
                var consulta = dbContext.Asegurado.Where(x => x.Id.Equals(asegurado.Id)).FirstOrDefault();

                if (consulta != null)
                {

                    asegurado.Id = consulta.Id;
                    consulta.Cedula = asegurado.Cedula;
                    consulta.Nombre = asegurado.Nombre;
                    consulta.Edad = asegurado.Edad;
                    consulta.Telefono = asegurado.Telefono;
                    dbContext.SaveChanges();

                    resultado.Codigo = 200;
                    resultado.Datos = asegurado;
                    resultado.Mensaje = "Éxito";
                }
                else
                {
                    resultado.Codigo = 500;
                    resultado.Datos = null;
                    resultado.Mensaje = "No existe el asegurado que intenta modificar";
                }


            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al modificar asegurado: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<Asegurado> Eliminar(long id)
        {
            var resultado = new IRespuesta<Asegurado>();
            try
            {
                var consulta = dbContext.Asegurado.Where(x => x.Id.Equals(id)).FirstOrDefault();

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
                    resultado.Mensaje = "No existe el asegurado que intenta eliminar";
                }


            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al eliminar asegurado: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<Asegurado> Consultar(long id)
        {
            var resultado = new IRespuesta<Asegurado>();
            try
            {
                var consulta = dbContext.Asegurado.Where(x => x.Id.Equals(id)).FirstOrDefault();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar asegurado: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<List<Asegurado>> ConsultarTodos()
        {
            var resultado = new IRespuesta<List<Asegurado>>();
            try
            {
                var consulta = dbContext.Asegurado.ToList();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar asegurado: " + ex.Message.ToString();
            }

            return resultado;
        }
    }
}
