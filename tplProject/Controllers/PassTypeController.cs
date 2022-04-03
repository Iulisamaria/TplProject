using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tplProject.Models.Repositories;
using tplProject.ViewModels;

namespace tplProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassTypeController : ControllerBase
    {
        public IPassType _passType;
        public PassTypeController(IPassType passType)
        {
            _passType = passType;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddPassType(AddPassTypeViewModel passType)
        {
            try
            {
                 _passType.AddPassType(passType);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(BasePassTypeViewModel pass)
        {
            try
            {
                await _passType.Update(pass);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var passType = await _passType.Get(id);
                return Ok(passType);
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
                await _passType.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }

}

