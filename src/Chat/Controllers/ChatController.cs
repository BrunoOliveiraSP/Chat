using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Chat.Model;

namespace Chat.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        static Dictionary<string, List<Messages>> messagesByRoom = 
           new Dictionary<string, List<Messages>>();


        [HttpPost("Entrar/{sala}")]
        public ActionResult Entrar(string sala, [FromBody] Messages message)
        {
            List<Messages> messages;
            if (!messagesByRoom.TryGetValue(sala, out messages))
            {
                messages = new List<Messages>();
                messagesByRoom.Add(sala, messages);
            }
            messages.Add(message);

            return Json(messages);
        }

        [HttpGet("Carregar/{sala}")]
        public ActionResult Carregar(string sala)
        {
            List<Messages> messages;
            if (!messagesByRoom.TryGetValue(sala, out messages))
            {
                messages = new List<Messages>();
                messagesByRoom.Add(sala, messages);
            }

            return Json(messages);
        }


        [HttpPost("Postar/{sala}")]
        public void Postar(string sala, [FromBody] Messages message)
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
