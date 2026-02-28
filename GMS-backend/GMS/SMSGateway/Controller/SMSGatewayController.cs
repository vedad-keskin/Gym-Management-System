using GMS.SMSGateway.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace GMS.SMSGateway.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSGatewayController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SMSGatewayController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/TwilioMess")]

        public IActionResult PosaljiPoruku()
        {
            var twilioConfigPath = _configuration.GetValue<string>("SMSGateway/Json/twilioConfig.json");
            var twilioConfigString = System.IO.File.ReadAllText("SMSGateway/Json/twilioConfig.json");
            var twilioConfig = JsonSerializer.Deserialize<TwilioConfig>(twilioConfigString);


            TwilioClient.Init(twilioConfig.AccountSID, twilioConfig.AuthToken);

            var poruka = MessageResource.Create(
                body:"Zakazan vam je termin od strane klijenta",
                from: new Twilio.Types.PhoneNumber("+16184932926"),
                to: new Twilio.Types.PhoneNumber("+38762709689")
                );


            return Ok(poruka.Sid);
        }
    }
}
