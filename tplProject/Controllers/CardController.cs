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
    public class CardController : ControllerBase
    {
        public readonly ICard _card;
        public CardController(ICard card)
        {
            _card = card;
        }
        //AddRoutes
        [HttpPost("addTickets/{Cnp}")]
        public async Task<IActionResult> AddTickets(int ticketNumber, decimal Cnp)
        {
            try
            {
                await _card.AddTickets(ticketNumber, Cnp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //update when change pass type 
        [HttpPost("{Cnp}")]
        public async Task<IActionResult> Update(BaseCardViewModels card, decimal Cnp)
        {
            try
            {
                await _card.Update(card, Cnp);
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
                return BadRequest(ex);
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
                return BadRequest( ex.Message);
            }
        }
    }
}
