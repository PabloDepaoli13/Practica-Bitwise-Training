﻿using System.Net;

namespace AppBibliotecaBitwise7.Models
{
    public class RespuestaApi
    {
        public RespuestaApi() 
        { 
            ErrorMenssages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; } 

        public List<string> ErrorMenssages { get; set; }

        public object Result { get; set; }
    }
}
