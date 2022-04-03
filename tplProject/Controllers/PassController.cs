using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tplProject.Models.Repositories;
using tplProject.ViewModels;

namespace tplProject.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PassController : ControllerBase
    {
        public IPass _pass;
        public PassController(IPass pass)
        {
            _pass = pass;
        }
        [HttpPost("{Cnp}")]
        public async Task<IActionResult> AddPass(AddPassViewModel pass,decimal Cnp)
        {
            try
            {
               // _pass.AddPass(pass,Cnp);
                return Ok("CNP este:"+Cnp+pass);
            }
            catch
            {
                return BadRequest();    
            }
        }
    }

}
