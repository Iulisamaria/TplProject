using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tplProject.Models.Repositories;
using tplProject.ViewModels;


namespace tplProject.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class LostItemsController : ControllerBase
    {
        public readonly ILostItems _lostItems; 
        public LostItemsController(ILostItems lostItems)
        {
            _lostItems = lostItems;
        }

      
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddLoseItemsViewModel lostItems)
        {
            try
            {
                  _lostItems.AddLostItems(lostItems);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("Error"+ex);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(BaseLostItemsViewModel lostItems)
        {
            try
            {
                await _lostItems.Update(lostItems);
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
                await _lostItems.Get(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error"+ex);
            }
        }
    }
}
