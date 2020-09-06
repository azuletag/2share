using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class Response : IResponse
    {
        public string MessageCode { get; set; }
        public string Message { get; set; }

        public Response(string messageCode, string message)
        {
            this.MessageCode = messageCode;
            this.Message = message;
        }
    }
}
