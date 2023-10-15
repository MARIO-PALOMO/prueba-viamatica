using consultorio_seguros_api.Contexto;
using consultorio_seguros_api.Contratos;
using consultorio_seguros_api.Entidad;
using Microsoft.EntityFrameworkCore;
using static consultorio_seguros_api.Utilitarios.Respuesta;

namespace consultorio_seguros_api.Modelo
{
    public class MSeguroAsegurado : IMSeguroAsegurado
    {
        private readonly svrlogsContext dbContext;
        public MSeguroAsegurado(svrlogsContext dbContext) { 
            this.dbContext = dbContext;
        }
        public IRespuesta<SeguroAsegurado> Guardar(SeguroAsegurado seguroAsegurado)
        {
            var resultado = new IRespuesta<SeguroAsegurado>();
            try
            {
                var datos = dbContext.Set<SeguroAsegurado>();
                datos.Add(seguroAsegurado);
                dbContext.SaveChanges();

                resultado.Codigo = 200;
                resultado.Datos = seguroAsegurado;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al guardar asignación: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<SeguroAsegurado> Eliminar(long id)
        {
            var resultado = new IRespuesta<SeguroAsegurado>();
            try
            {
                var consulta = dbContext.SeguroAsegurado.Where(x => x.Id.Equals(id)).FirstOrDefault();

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
                    resultado.Mensaje = "No existe la asignación que intenta eliminar";
                }


            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al eliminar asignación: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<List<SeguroAsegurado>> ConsultarTodos()
        {
            var resultado = new IRespuesta<List<SeguroAsegurado>>();
            try
            {
                var consulta = dbContext.SeguroAsegurado.Include(x=>x.Seguro).Include(x => x.Asegurado).ToList();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar Asignación: " + ex.Message.ToString();
            }

            return resultado;
        }


        public IRespuesta<List<SeguroAsegurado>> ConsultarCedula(string cedula)
        {
            var resultado = new IRespuesta<List<SeguroAsegurado>>();
            try
            {
                var consulta = dbContext.SeguroAsegurado.Include(x => x.Seguro).Include(x => x.Asegurado).Where(x => x.Asegurado.Cedula.Equals(cedula)).ToList();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar Asignación: " + ex.Message.ToString();
            }

            return resultado;
        }

        public IRespuesta<List<SeguroAsegurado>> ConsultarCodigo(string codigo)
        {
            var resultado = new IRespuesta<List<SeguroAsegurado>>();
            try
            {
                var consulta = dbContext.SeguroAsegurado.Include(x => x.Seguro).Include(x => x.Asegurado).Where(x => x.Seguro.Codigo.Equals(codigo)).ToList();

                resultado.Codigo = 200;
                resultado.Datos = consulta;
                resultado.Mensaje = "Éxito";
            }
            catch (Exception ex)
            {
                resultado.Codigo = 500;
                resultado.Datos = null;
                resultado.Mensaje = "Error al consultar Asignación: " + ex.Message.ToString();
            }

            return resultado;
        }

    }
}
