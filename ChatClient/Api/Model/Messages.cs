using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Api.Model
{
    class Messages
    {
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Inclusion { get; set; }
    }
}
