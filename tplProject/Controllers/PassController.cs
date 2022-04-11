using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> AddPass(AddPassViewModel pass,decimal Cnp,int time)
        {
            try
            {
              await _pass.AddPass(pass,Cnp,time
                  );
                return Ok("CNP este:"+Cnp+pass);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);    
            }
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(BasePassViewModel pass)
        {
            try
            {
                await _pass.Update(pass);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               var pass= await _pass.Get(id);
                return Ok(pass);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpGet("getAbonamentByUserId/{userId}")]
        public async Task<IActionResult> GetAbonamentById(int userId)
        {
            try
            {
                var pass = await _pass.GetAbonament(userId);
                return Ok(pass);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpGet("getTickets/{cnp}")]
        public async Task<IActionResult> GetTickets(decimal cnp)
        {
            try
            {
                var card = await _pass.GetTickets(cnp);
                return Ok(card.Routes);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pass.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }

}
