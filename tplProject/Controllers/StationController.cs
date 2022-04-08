using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tplProject.Models.Repositories.Station;
using tplProject.ViewModels;

namespace tplProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StationController : Controller
    {
        public IStation _station;
        public StationController(IStation station)
        {
            _station = station;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddStationViewModel station)
        {
            try
            {
                _station.AddStation(station);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(BaseStationViewModel station)
        {
            try
            {
                await _station.Update(station);
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
                var passType = await _station.Get(id);
                return Ok(passType);
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
                var passType = await _station.GetAll();
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
                await _station.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }
}
