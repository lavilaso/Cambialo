using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Models.Responses
{
    public class Response<T>
    {
        public bool Succeded { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }
        public T Data { get; private set; }

        public Response(string message, bool succeded, T data = default)
        {
            Message = message;
            Succeded = succeded;

        }

        public Response(string message, T data = default)
        {
            if (data == null)
            {
                Succeded = false;
            }
            else
            {
                Succeded = true;
            }
            Message = message;
            Data = data;
        }

        public Response(string message, List<string> errors)
        {
            Message = message;
            Errors = errors;
        }
    }
}
