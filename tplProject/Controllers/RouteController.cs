using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tplProject.Models.Repositories;
using tplProject.ViewModels;

namespace tplProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRoute _route;

        public RouteController(IRoute route)
        {
            _route = route;
        }
        [HttpPost("add")]

        public async Task<IActionResult>Add(AddRouteViewModel route)
        {
            try
            {
                _route.AddRoute(route);
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
                var route = await _route.Get(id);
                return Ok(route);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var route = await _route.GetAll();
                return Ok(route);
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateRouteViewModel route)
        {
            try
            {
                await _route.Update(route);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _route.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }
}
