
using System.Net;

namespace AppBibliotecaBitwise8.Models
{
    public class RespuestaAPI
    {
        public RespuestaAPI()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool isSucces { get; set; }

        public List<string> ErrorMessages { get; set; }

        public object Result { get; set; }
    }
   
}
