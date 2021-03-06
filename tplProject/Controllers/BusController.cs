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
    [Route("[controller]")]
    [ApiController]
    
    public class BusController : ControllerBase
    {
        public readonly IBus _bus;
        public BusController(IBus bus)
        {
            _bus = bus;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               var bus= await _bus.Get(id);
                return Ok(bus);
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var bus = await _bus.GetAll();
                return Ok(bus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBus(AddBussViewModel buss)
        {
            try
            {
                 _bus.AddBus(buss);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(BaseBusViewModel buss)
        {
            try
            {
                await _bus.Update(buss);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest( ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bus.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }
    }
}
