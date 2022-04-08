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
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var card=await _card.Get(id);
                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("getpass/{cnp}")]
        public async Task<IActionResult> GetPass(decimal cnp)
        {
            try
            {
                var pass =await _card.GetPass(cnp);
                return Ok(pass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("gettickets/{cnp}")]
        public async Task<IActionResult> GetTickets(decimal cnp)
        {
            try
            {
                var tickets = await _card.GetTickets(cnp);
                return Ok(tickets);
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
