using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Api
{
    class ChatService
    {
        HttpService _httpService;
        public ChatService()
        {
            _httpService = new HttpService();
        }

        public List<Model.Messages> EnterRoom(string room)
        {
            var response = _httpService.Get("http://191.235.85.153:5000/api/Chat/Sala/" + room);
            var messages = JsonConvert.DeserializeObject<List<Model.Messages>>(response);
            return messages;
        }

        public List<Model.Messages> LoadMessages(string room)
        {
            var response = _httpService.Get("http://191.235.85.153:5000/api/Chat/Sala/" + room);
            var messages = JsonConvert.DeserializeObject<List<Model.Messages>>(response);
            return messages;
        }

        public void PostMessages(string room, string user, string messageText)
        {
            var message = new Model.Messages()
            {
                User = user,
                Message = messageText,
                Inclusion = DateTime.Now
            };
            var contentJson = JsonConvert.SerializeObject(message);

            var response = _httpService.Post("http://191.235.85.153:5000/api/Chat/Sala/" + room, contentJson);
        }


    }
}
