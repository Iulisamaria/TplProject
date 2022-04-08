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
        public async Task<IActionResult> Add(AddLostItemsViewModel lostItems)
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
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               var lostItems =await _lostItems.Get(id);
                return Ok(lostItems);
            }
            catch (Exception ex)
            {
                return BadRequest("Error"+ex);
            }
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var route = await _lostItems.GetAll();
                return Ok(route);
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
                await _lostItems.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex.Message);
            }
        }
    }
}
