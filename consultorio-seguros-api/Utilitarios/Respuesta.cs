using Newtonsoft.Json;

namespace consultorio_seguros_api.Utilitarios
{

    public class Respuesta
    {
        public class RespuestaBase
        {
            [JsonProperty("codigo")]
            public int Codigo { get; set; }

            [JsonProperty("mensaje")]
            public string Mensaje { get; set; }

        }

        public class IRespuesta<T> : RespuestaBase
        {
            [JsonProperty("datos")]
            public T Datos { get; set; }
        }
    }

}
