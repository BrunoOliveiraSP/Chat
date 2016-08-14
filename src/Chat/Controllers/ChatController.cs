using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Chat.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        public class Messages
        {
            public string User { get; set; }
            public string Message { get; set; }
            public DateTime Inclusion { get; set; }
        }

        static Dictionary<string, List<Messages>> messagesByRoom = new Dictionary<string, List<Messages>>();


        [HttpGet("Sala/{sala}")]
        public ActionResult Rooms(string sala)
        {
            List<Messages> messages;
            if (!messagesByRoom.TryGetValue(sala, out messages))
            {
                messages = new List<Messages>();
                messagesByRoom.Add(sala, messages);
            }

            return Json(messages);
        }


        [HttpPost("Sala/{sala}")]
        public void NovaMensagem(string sala, [FromBody]Messages message)
        {
            List<Messages> messages;
            if (!messagesByRoom.TryGetValue(sala, out messages))
            {
                messages = new List<Messages>();
                messagesByRoom.Add(sala, messages);
            }

            messages.Add(message);
        }
        
    }
}
