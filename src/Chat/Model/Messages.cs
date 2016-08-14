using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Model
{
    public class Messages
    {
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Inclusion { get; set; }
    }
}
