using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tplProject.Models.Repositories.SendMail;

namespace tplProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly ISend _send;
        public SendMailController(ISend send)
        {
            _send = send;
        }
        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> SendMail(string YourEmail, string YourSubject, String YourName, String Comments)
        {
            try
            {
                _send.SendMail(YourEmail, YourSubject, YourName, Comments);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
