using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tplProject.Models.Repositories;

namespace tplProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public readonly ICard _card;
        public CardController(ICard card)
        {
            _card = card;
        }
        [HttpPost("{Cnp}")]
        public async Task<IActionResult> Update(int ticketNumber, decimal Cnp)
        {
            try
            {
                await _card.UpdateRoutes(ticketNumber, Cnp);
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
                await _card.Get(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error Cristi was here... laptopul nu se lasa deschis...." + ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _card.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error Cristi was here... laptopul nu se lasa deschis...." + ex.Message);
            }
        }
    }
}
