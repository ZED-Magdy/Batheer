using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Batheer.WebUI.Services
{
    public class SMSService
    {
        private IConfiguration _configuration { get; }

        public SMSService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<(string messageId, string jsonString, bool isSucess)> Send(string body, string recipients)
        {

            if (_configuration.GetValue<bool>("taqnyat:disabled"))
            {
                return Task.FromResult((string.Empty, "disabled", true));
            }

            string fake_mobile = _configuration.GetValue<string>("taqnyat:fake_mobile");

            if (string.IsNullOrEmpty(fake_mobile) == false)
            {
                recipients = fake_mobile;
            }


            Taqnyat.Taqnyat taqnyt = new Taqnyat.Taqnyat();
            string bearer = _configuration.GetValue<string>("taqnyat:bearer"); 
            string sender = _configuration.GetValue<string>("taqnyat:SenderName");


            var jsonString = taqnyt.SendMessage(bearer, recipients, sender, body); //"{\"statusCode\":201,\"messageId\":5797779384}";  //
            dynamic data = JsonConvert.DeserializeObject(jsonString);

            bool isSucess = data.statusCode == "201";
            string messageId = Convert.ToString(data.messageId);
            return Task.FromResult((messageId, jsonString, isSucess));
        }
    }
}
