using System.Net;

namespace AppBibliotecaBitwise6.Models
{
    public class RespuestaAPI
    {
        public RespuestaAPI()
        {
            ErrorMessage = new List<string>();
        }
        public List<string> ErrorMessage { get; set; }

        public bool isSucces { get; set; }

        public HttpStatusCode StatusCode { get; set;}

        public object Resultado { get; set; }
    }
}
